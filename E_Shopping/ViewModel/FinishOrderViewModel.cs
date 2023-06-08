using DevExpress.PivotGrid.OLAP;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.UserControlBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class FinishOrderViewModel:BaseViewModel
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
        public FinishOrderViewModel()
        {
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => { LoadOrderData(); });
            SelectionChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                ProductList = new ObservableCollection<Product_order>();
                if (SelectedOrder != null)
                    LoadProductData(SelectedOrder);
            });
            ConfirmCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Order_finish temp = SelectedOrder;
                if(temp != null)
                {
                    var rec = DataProvider.ins.db.RECEIPTs.Where(x => x.id == temp.re.id).SingleOrDefault();
                    if(rec != null)
                    {
                        rec.status = 1;
                        DataProvider.ins.db.SaveChanges();
                        LoadOrderData();
                        SucceedNotify succeedNotify = new SucceedNotify();
                        succeedNotify.ShowDialog();

                        var finishorder = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idReceipt == rec.id);
                        if(finishorder != null)
                        {
                            foreach(ORDERSRECEIPT or in finishorder)
                            {
                                var od = DataProvider.ins.db.ORDERS.Where(x => x.id == or.idOrder).SingleOrDefault();
                                od.status = 3;
                            }
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                }
                //var orders = DataProvider.ins.db.ORDERS.Where(o => o.idCart == temp.order.idCart);
                //if (orders != null)
                //{
                //    int orderid = -1;

                //    foreach (var order in orders)
                //    {

                //        //order.status = 2;
                //        orderid = order.id;
                //    }
                //    //DataProvider.ins.db.SaveChanges();
                //    //SelectedOrder = null;
                //    //LoadOrderData();


                //    if (orderid != -1)
                //    {

                //        var orderrec = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idOrder == orderid).SingleOrDefault();
                //        if (orderrec != null)
                //        {

                //            var rec = DataProvider.ins.db.RECEIPTs.Find(orderrec.idReceipt);
                //            if (rec != null)
                //            {
                //                rec.status = 1;
                //                DataProvider.ins.db.SaveChanges();
                //                LoadOrderData();
                //            }
                //        }
                //    }

                //    SucceedNotify succeedNotify = new SucceedNotify();
                //    succeedNotify.ShowDialog();
                //}

            });
        }
        void LoadOrderData()
        {
            OrderList = new ObservableCollection<Order_finish>();
            var orders = DataProvider.ins.db.ORDERS;

            

            List<Int32> OrderID = new List<Int32>();

            var receipts = DataProvider.ins.db.RECEIPTs;
            if(receipts != null)
            {
                foreach (RECEIPT re in receipts)
                {
                    if(re.status == -1)
                    {
                        var customer = DataProvider.ins.db.PEOPLE.Where(p => p.id == re.idCustomer).SingleOrDefault();
                        if(customer != null)
                        {
                            OrderList.Add(new Order_finish(re, customer.name, customer.phoneNumber));
                        }
                    }
                }
            }
            


            //if (orders != null)
            //{
            //    List<Int32> cartList = new List<Int32>();
            //    foreach (var o in orders)
            //    {
            //        var orderrec = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idOrder == o.id);
            //        if(orderrec != null)
            //        {
            //            foreach(ORDERSRECEIPT or in orderrec)
            //            {
            //                if (!(checkId(OrderID, or.idReceipt)))
            //                {
            //                    OrderID.Add(or.idReceipt);
            //                }
            //            }
            //        }
                    
            //    }
                
            //    foreach (var o in orders)
            //    {
            //        foreach (Int32 temp in OrderID)
            //        {
            //            var rec = DataProvider.ins.db.RECEIPTs.Find(temp);
            //            if (rec != null)
            //            {
            //                if (rec.status == 0 && o.status == 2)
            //                {
            //                    var cart = DataProvider.ins.db.CARTs.Where(c => c.id == o.idCart).FirstOrDefault();

            //                    var customer = DataProvider.ins.db.PEOPLE.Where(p => p.id == cart.idCustomer).SingleOrDefault();
            //                    if (!checkId(cartList, System.Convert.ToInt32(cart.id)))
            //                    {
            //                        Order_finish order_Finish = new Order_finish(o, customer.name, customer.phoneNumber);
            //                        OrderList.Add(order_Finish);
            //                    }
            //                    cartList.Add(System.Convert.ToInt32(o.idCart));
            //                }
            //            }
            //        }
            //    }

               
            


        }
        Boolean checkId(List<Int32> l, Int32 id)
        {
            foreach (var item in l)
            {
                if (item == id)
                    return true;
            }
            return false;
        }

        void LoadProductData(Order_finish co)
        {
            //var orders = DataProvider.ins.db.ORDERS.Where(o => o.idCart == co.order.idCart);
            //if (orders != null)
            //{
            //    foreach (ORDER oRDER in orders)
            //    {

            //        var products = DataProvider.ins.db.PRODUCTs.Where(p => p.id == oRDER.idProduct).SingleOrDefault();
            //        if (products != null)
            //        {
            //            Product_order product_Order = new Product_order(products.id, products.name, oRDER);
            //            ProductList.Add(product_Order);
            //        }
            //    }
            //}

            var orderrec = DataProvider.ins.db.ORDERSRECEIPTs.Where(x => x.idReceipt == co.re.id);
            if(orderrec != null)
            {
                foreach(var item in orderrec)
                {
                    var order = DataProvider.ins.db.ORDERS.Where(x => x.id == item.idOrder);
                    if(order != null)
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
