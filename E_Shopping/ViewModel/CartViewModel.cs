using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class CartViewModel :BaseViewModel
    {
        private static ObservableCollection<ORDER> _shoppingCarts;
        public ObservableCollection<ORDER> shoppingCarts { get => _shoppingCarts; set { _shoppingCarts = value; OnPropertyChanged(); } }
        private static ObservableCollection<ORDER> _itemIsBuy;
        public ObservableCollection<ORDER> itemIsBuy { get => _itemIsBuy; set { _itemIsBuy = value; OnPropertyChanged(); } }

        private static  double _subTotal;
        public double subTotal { get => _subTotal; set { _subTotal = value; OnPropertyChanged(); } }

        public static ObservableCollection<ORDER> getitembuy()
        {
            return _itemIsBuy;
        }

        public ICommand ProceedCheckoutCommand { get; set; }
        private void ShippingDetail()
        {
            itemIsBuy.Clear();
            foreach(ORDER cart in shoppingCarts)
            {
                if (cart.check==true)
                {
                    itemIsBuy.Add(cart);
                }
            }
            if (itemIsBuy.Count==0)
            {
                ValidationNotify validationNotify = new ValidationNotify();
                validationNotify.content.Text = "You need to select an item!!";
                validationNotify.ShowDialog();
                return;
            }
            // ShippingAddressViewModel shippingAddressViewModel = new ShippingAddressViewModel() { listItem=itemIsBuy,subTotal=subTotal} ;
            ShippingAddressViewModel.Instance = new ShippingAddressViewModel() { listItem = itemIsBuy, subTotal = subTotal };
            MainViewModel.Instance.CurrentView = ShippingAddressViewModel.Instance;
            MainViewModel.addViewToStack(ShippingAddressViewModel.Instance);
        }
        public CartViewModel() {
            itemIsBuy = new ObservableCollection<ORDER>();

            //Chỉnh thành những item chưa được mua
            //Mốt chỉnh idcart thành idcart của user
            shoppingCarts = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(p=>p.idCart==2 && p.status==0));

            //shoppingCarts = new ObservableCollection<ShoppingCart>();
            //shoppingCarts.Add(new ShoppingCart() { name = "Thanh Long", image = "https://vinmec-prod.s3.amazonaws.com/images/20210419_031329_240031_qua-thanh-long.max-1800x1800.jpg", quantity = 2, price = 100000000 ,check=false});
            //shoppingCarts.Add(new ShoppingCart() { name = "Nhãn", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 1, price = 200000,check=false});
            //shoppingCarts.Add(new ShoppingCart() { name = "Xoài", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 1, price = 200000,check=false});
            //shoppingCarts.Add(new ShoppingCart() { name = "Đu Đủ", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 1, price = 200000,check=false});
            ////subTotal=calculateSubTotal();
            ProceedCheckoutCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => {
                //MainViewModel.returnToEmptyCard();
                ShippingDetail();
            }
            );

        }

        public double calculateSubTotal()
        {
            double Total = 0;
            foreach (ORDER item in shoppingCarts)
            {
                if (item!=null)
                {
                    if (item.check == true)
                    {
                        PRODUCT p = DataProvider.ins.DB.PRODUCTs.Where(m => m.id == item.idProduct).FirstOrDefault();


                        Total += Double.Parse((item.quantity * item.PRODUCT.price).ToString());
                    }
                }
               
            }
            subTotal=Total;
            return Total;
        }
        public void deleteItemIsBought()
        {
            itemIsBuy.Clear();
            //ObservableCollection<ORDER> temp = new ObservableCollection<ORDER>();
            //foreach(ORDER item in shoppingCarts)
            //{
            //    if (item!=null)
            //    {
            //        if (item.status==0)
            //        {
            //            temp.Add(item);
            //        }
            //    }
            //}
            shoppingCarts.Clear();
            shoppingCarts= new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(p => p.idCart == 2 && p.status == 0));
            //shoppingCarts = temp;
            subTotal = 0;
        }
    }
}
