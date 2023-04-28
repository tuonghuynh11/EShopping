using E_Shopping.Model;
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
        private ObservableCollection<Customer_order> _orderList;
        public ObservableCollection<Customer_order> OrderList { get => _orderList; set { _orderList = value; OnPropertyChanged(); } }

        private Customer_order _selectedOrder;
        public Customer_order SelectedOrder { get => _selectedOrder; set { _selectedOrder = value; OnPropertyChanged(); } }

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
                Customer_order temp = SelectedOrder;
                var orders = DataProvider.ins.db.ORDERS.Where(o => o.idCart == temp.order.idCart);
                if(orders != null)
                {
                    foreach (var order in orders)
                    {
                        order.status = 1;
                    }
                    DataProvider.ins.db.SaveChanges();
                    SelectedOrder = null;
                    LoadOrderData();
                    MessageBox.Show("Confirm");
                }
                
            });
            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Customer_order temp = SelectedOrder;
                var orders = DataProvider.ins.db.ORDERS.Where(o => o.idCart == temp.order.idCart);
                if (orders != null)
                {
                    foreach (var order in orders)
                    {
                        order.status = -1;
                    }
                    DataProvider.ins.db.SaveChanges();
                    SelectedOrder = null;
                    LoadOrderData();
                    MessageBox.Show("Cancel");
                }

            });
        }
        void LoadOrderData()
        {
            OrderList = new ObservableCollection<Customer_order>();
            var orders = DataProvider.ins.db.ORDERS;
            if(orders != null)
            {
                List<Int32> cartList = new List<Int32>();
                foreach (var o in orders)
                {
                    //Status = 1 thi da duoc confirm, status = -1 thi bi cancel
                    if (o.status == 0)
                    {
                        var cart = DataProvider.ins.db.CARTs.Where(c => c.id == o.idCart).FirstOrDefault();

                        var customer = DataProvider.ins.db.PEOPLE.Where(p => p.id == cart.idCustomer).SingleOrDefault();
                        if (!checkId(cartList, System.Convert.ToInt32(cart.id)))
                        {
                            Customer_order customer_Order = new Customer_order(o, customer.name);
                            OrderList.Add(customer_Order);
                        }
                        cartList.Add(System.Convert.ToInt32(o.idCart));
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

        void LoadProductData(Customer_order co)
        {
            var orders = DataProvider.ins.db.ORDERS.Where(o => o.idCart == co.order.idCart);
            if (orders != null)
            {
                foreach (ORDER oRDER in orders)
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
