using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

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

        public static int checkChange = 0;
       public int flag = 0;
        public OrderedHistory()
        {
            InitializeComponent();
           
            this.orderedHistoryViewModel = new OrderedHistoryViewModel();

            //Group product theo id đơn hàng
            lvBuying.ItemsSource = orderedHistoryViewModel.buyingList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvBuying.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("idReceipt");
            view.GroupDescriptions.Add(groupDescription);

            //Timer for chatbox
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Update Current Order
            orderedHistoryViewModel.buyingList= new ObservableCollection<ORDER>(DataProvider.ins.db.ORDERS.Where(p => (p.status == 1 || p.status == 2) && p.idCart == AccessUser.currentUser.idCart));
            lvBuying.ItemsSource = orderedHistoryViewModel.buyingList;
            //Group product theo id đơn hàng
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvBuying.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("idReceipt");
            view.GroupDescriptions.Add(groupDescription);


            //Update History
            if (flag == 0)
            {
                flag = 1;
                checkChange = DataProvider.ins.DB.ORDERS.Where(p => p.status == 3).Count();
                return;
            }
            else
            {
                if (DataProvider.ins.DB.ORDERS.Where(p => p.status == 3).Count() != checkChange)
                {
                    orderedHistoryViewModel.boughtList = new ObservableCollection<ORDER>(DataProvider.ins.db.ORDERS.Where(p => p.status == 3 && p.idCart == AccessUser.currentUser.idCart));

                    orderedHistoryViewModel.productCategory = new ObservableCollection<CATEGORY>();
                    var productCategoryReplace = orderedHistoryViewModel.boughtList
                        .Join(DataProvider.ins.DB.CATEGORies,
                        p => p.idProductType,
                        k => k.id,
                        (p, k) => new CATEGORY()
                        {
                            id = k.id,
                            type = k.type,
                        });

                    List<CATEGORY> distinctCategory = productCategoryReplace
                                                      .GroupBy(m => m.type)
                                                      .Select(g => g.First())
                                                       .ToList();
                    orderedHistoryViewModel.productCategory.Add(new CATEGORY() { type = "ALL" });

                    foreach (CATEGORY category in distinctCategory)
                    {
                        orderedHistoryViewModel.productCategory.Add(category);
                    }
                    categoryDataGrid.ItemsSource = orderedHistoryViewModel.productCategory;
                    itemboughtlist.ItemsSource = orderedHistoryViewModel.boughtList;

                    checkChange = DataProvider.ins.DB.ORDERS.Where(p => p.status == 3).Count();
                }
            }
          


            
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
            MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.db.MANAGEPRODUCTSYSTEMs.Find(product.idProduct);

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

          
            ORDER order = new ORDER() { idCart = AccessUser.currentUser.idCart, idProduct = product.idProduct, quantity = 1, date = DateTime.Today, status = 0 };
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
           
            RateProduc rateProduc = new RateProduc(AccessUser.currentUser.id, product);
            rateProduc.ShowDialog();
        }
    }
}
