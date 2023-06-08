using E_Shopping.Model;
using E_Shopping.PopUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class ConfirmOrderViewModel:BaseViewModel
    {
        private ObservableCollection<Order_finish> _orderList;
        public ObservableCollection<Order_finish> OrderList { get => _orderList; set { _orderList = value; OnPropertyChanged(); } }

        private Order_finish _selectedOrder;
        public Order_finish SelectedOrder { get => _selectedOrder; set { _selectedOrder = value; OnPropertyChanged(); } }

        private ObservableCollection<Product_order> _productList;
        public ObservableCollection<Product_order> ProductList { get => _productList; set { _productList = value; OnPropertyChanged(); } }

        

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ConfirmOrderViewModel()
        {
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => { LoadOrderData(); });
            SelectionChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                ProductList = new ObservableCollection<Product_order>();
                if(SelectedOrder != null)
                    LoadProductData(SelectedOrder);
            });
            ConfirmCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Order_finish temp = SelectedOrder;
                if (temp != null)
                {
                    var rec = DataProvider.ins.db.RECEIPTs.Where(x => x.id == temp.re.id).SingleOrDefault();
                    if (rec != null)
                    {
                        rec.status = -1;
                        DataProvider.ins.db.SaveChanges();
                        LoadOrderData();
                        SucceedNotify succeedNotify = new SucceedNotify();
                        succeedNotify.ShowDialog();

                        var finishorder = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idReceipt == rec.id);
                        if (finishorder != null)
                        {
                            foreach (ORDERSRECEIPT or in finishorder)
                            {
                                var od = DataProvider.ins.db.ORDERS.Where(x => x.id == or.idOrder).SingleOrDefault();
                                od.status = 2;
                            }
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                }
                
                
            });
            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Order_finish temp = SelectedOrder;
                if (temp != null)
                {
                    var rec = DataProvider.ins.db.RECEIPTs.Where(x => x.id == temp.re.id).SingleOrDefault();
                    if (rec != null)
                    {
                        rec.status = 0;
                        DataProvider.ins.db.SaveChanges();
                        LoadOrderData();
                        ValidationNotify validationNotify = new ValidationNotify("Cancel order");
                        validationNotify.ShowDialog();

                        var finishorder = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idReceipt == rec.id);
                        if (finishorder != null)
                        {
                            foreach (ORDERSRECEIPT or in finishorder)
                            {
                                var od = DataProvider.ins.db.ORDERS.Where(x => x.id == or.idOrder).SingleOrDefault();
                                od.status = -1;
                            }
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                }

            });
        }
        void LoadOrderData()
        {
            OrderList = new ObservableCollection<Order_finish>();
            var orders = DataProvider.ins.db.ORDERS;



            List<Int32> OrderID = new List<Int32>();

            var receipts = DataProvider.ins.db.RECEIPTs;
            if (receipts != null)
            {
                foreach (RECEIPT re in receipts)
                {
                    if (re.status == 0)
                    {
                        var customer = DataProvider.ins.db.PEOPLE.Where(p => p.id == re.idCustomer).SingleOrDefault();
                        if (customer != null)
                        {
                            OrderList.Add(new Order_finish(re, customer.name, customer.phoneNumber));
                        }
                    }
                }
            }


        }
        Boolean checkId(List<Int32> l, Int32 id)
        {
            foreach(var item in l)
            {
                if(item == id)
                    return true;
            }
            return false;
        }

        void LoadProductData(Order_finish co)
        {
            
            var orderrec = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idReceipt == co.re.id);
            if (orderrec != null)
            {
                foreach (var item in orderrec)
                {
                    var order = DataProvider.ins.db.ORDERS.Where(x => x.id == item.idOrder);
                    if (order != null)
                    {
                        foreach (ORDER oRDER in order)
                        {

                            var products = DataProvider.ins.db.PRODUCTs.Where(p => p.id == oRDER.idProduct).SingleOrDefault();
                            if (products != null)
                            {
                                Product_order product_Order = new Product_order(products.id, products.name, oRDER);
                                ProductList.Add(product_Order);
                            }
                        }
                    }
                }
            }

        }
    }
}
