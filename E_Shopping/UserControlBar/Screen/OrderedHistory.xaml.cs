using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace E_Shopping.UserControlBar.Screen
{
    /// <summary>
    /// Interaction logic for OrderedHistory.xaml
    /// </summary>
    public partial class OrderedHistory : UserControl
    {
        List<CATEGORY> categories = new List<CATEGORY>();
        List<ORDER> carts = new List<ORDER>();

        public OrderedHistoryViewModel orderedHistoryViewModel;
        public OrderedHistory()
        {
            InitializeComponent();
            //categories.Add(new Category() { id = 1, name = "Electronic" });
            //categories.Add(new Category() { id = 2, name = "Meat"  });
            //categories.Add(new Category() { id = 3, name = "Medicine" });
            //categories.Add(new Category() { id = 4, name = "Machine1"});
            //categories.Add(new Category() { id = 4, name = "Machine2" });
            //categories.Add(new Category() { id = 4, name = "Machine3" });
            //categories.Add(new Category() { id = 4, name = "Machine4"});
            //categories.Add(new Category() { id = 4, name = "Machine5" });
            //categories.Add(new Category() { id = 4, name = "Machine6" });
            //categories.Add(new Category() { id = 4, name = "Machine7" });
            //categories.Add(new Category() { id = 4, name = "Machine8"});


            //carts.Add(new ShoppingCart() { name = "Thanh Long", image = "https://vinmec-prod.s3.amazonaws.com/images/20210419_031329_240031_qua-thanh-long.max-1800x1800.jpg", quantity = 222, price = 100000000, check = false ,category="Electronic",status="Waiting"});
            //carts.Add(new ShoppingCart() { name = "Nhãn", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 1, price = 200000, check = false,category="Meat", status = "Waiting" });
            //carts.Add(new ShoppingCart() { name = "Xoài", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 21, price = 200000, check = false,category="Meat", status = "Verified" });
            //carts.Add(new ShoppingCart() { name = "Đu Đủ", image = "https://bizweb.dktcdn.net/100/324/966/products/nhanxuongcomvang-c1876ecb-51c1-4db5-942e-e84e6d998158.jpg?v=1624982757580", quantity = 1, price = 200000, check = false,category="Medicine", status = "Verified" });


            //categories.Add(new Category() { id=1,name= "Electronic" });
            //categories.Add(new Category() { id=1,name= "Meat" });
            //categories.Add(new Category() { id=1,name= "Medicine" });
            //categories.Add(new Category() { id=1,name= "ALL" });
        
            //categoryDataGrid.ItemsSource = categories;
            //itemboughtlist.ItemsSource = carts;
            //itemBuyingDataGrid.ItemsSource=carts;
            this.orderedHistoryViewModel = new OrderedHistoryViewModel();

            //Group product theo id đơn hàng
            lvBuying.ItemsSource = orderedHistoryViewModel.buyingList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvBuying.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("idReceipt");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void searchtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            carts = orderedHistoryViewModel.boughtList.ToList();
            var tbx = (TextBox)sender;
            if (tbx.Text != "")
            {
                var filterList = carts.Where(x => x.prodductName.ToLower().Contains(tbx.Text.ToLower()));
                itemboughtlist.ItemsSource = null;
                itemboughtlist.ItemsSource = filterList;
            }
            else
            {
                itemboughtlist.ItemsSource = carts;
            }
        }

        private void applySearchbtn_Click(object sender, RoutedEventArgs e)
        {
            carts = orderedHistoryViewModel.boughtList.ToList();
            CATEGORY category = categoryDataGrid.SelectedItem as CATEGORY;
            if (category!=null)
            {
                if (category.type=="ALL")
                {
                    itemboughtlist.ItemsSource = carts;
                    return;
                }
                var filterList = carts.Where(x => x.productType == category.type);
                itemboughtlist.ItemsSource = null;
                itemboughtlist.ItemsSource = filterList;
            }
        }

        private void buyAgainbtn_Click(object sender, RoutedEventArgs e)
        {
            ORDER product = itemboughtlist.SelectedItem as ORDER;
            if (product==null)
            {
                return;
            }
            //Check xem sản phẩm còn hàng không
            MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Find(product.idProduct);

            if (available_quantiy.quantity == 0)
            {
                ValidationNotify validationNotify = new ValidationNotify("Product is out of stock");
                validationNotify.ShowDialog();
                return;
            }
            else
            {
                available_quantiy.quantity--;
                DataProvider.ins.DB.SaveChanges();
            }

            //  //Mốt chỉnh 2 thành id cart của current user
            ORDER order = new ORDER() { idCart = 2, idProduct = product.idProduct, quantity = 1, date = DateTime.Today, status = 0 };
            DataProvider.ins.DB.ORDERS.Add(order);
            DataProvider.ins.DB.SaveChanges();
            MainViewModel.Instance.CurrentView = new CartViewModel();
        }

        private void ratebtn_Click(object sender, RoutedEventArgs e)
        {
            ORDER product = itemboughtlist.SelectedItem as ORDER;
            if (product == null)
            {
                return;
            }
            //Mốt chỉnh 2 thành id của current user
            RateProduc rateProduc = new RateProduc(2, product);
            rateProduc.ShowDialog();
        }
    }
}
