using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.ViewModel;

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for DashboardUC.xaml
    /// </summary>
    public partial class DashboardUC : UserControl
    {
        private List<BitmapImage> Images = new List<BitmapImage>();
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        DispatcherTimer timer;
        int t1;
        public static int m = 0;

        public DashboardUC()
        {
            InitializeComponent();
            this.DataContext = new CategoryViewModel();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_tick;

            t1 = 0;
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/new_offer.jpg")));
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/LG.jpg")));
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/1.png")));
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/2.png")));


            Advertisement.Source = Images[0];
            
            timer.Start();
        }
        void timer_tick(object sender, EventArgs e)
        {
            t1 = (t1 + 1) % Images.Count;
            NextImage(Advertisement);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            //t1--;

            //if (t1 > 2)
            //{
            //    t1 = 3 % 2;
            //}
            //if(t1 < 1)
            //{
            //    t1 = 2;
            //}
            //string dx = "ad" + t1;
            //Advertisement.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + dx + ".jpg"));
            t1 = (t1 - 1);
            if(t1 == -1) { t1 = Images.Count - 1; }
            NextImage(Advertisement);
        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            //t1++;

            //if (t1 > 2)
            //{
            //    t1 = 3 % 2;
            //}
            //string dx = "ad" + t1;

            //Advertisement.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + dx + ".jpg"));

            t1 = (t1 + 1) % Images.Count;
            NextImage(Advertisement);
        }
        private void NextImage(Image advertisement)
        {
            const double transition_time = 0.9;
            Storyboard sb = new Storyboard();
            DoubleAnimation fade_out = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(transition_time));
            fade_out.BeginTime = TimeSpan.Zero;
            Storyboard.SetTarget(fade_out, advertisement);
            Storyboard.SetTargetProperty(fade_out, new PropertyPath(Image.OpacityProperty));
            sb.Children.Add(fade_out);

            ObjectAnimationUsingKeyFrames new_image_animation = new ObjectAnimationUsingKeyFrames();

            DiscreteObjectKeyFrame new_frame = new DiscreteObjectKeyFrame(Images[t1], TimeSpan.FromSeconds(transition_time));
            new_image_animation.KeyFrames.Add(new_frame);

            Storyboard.SetTarget(new_image_animation, advertisement);
            Storyboard.SetTargetProperty(new_image_animation, new PropertyPath(Image.SourceProperty));
            sb.Children.Add(new_image_animation);
            DoubleAnimation fade_in = new DoubleAnimation(0.0, 1.0, TimeSpan.FromSeconds(transition_time));
            fade_in.BeginTime = TimeSpan.FromSeconds(transition_time);

            Storyboard.SetTarget(fade_in, advertisement);
            Storyboard.SetTargetProperty(fade_in, new PropertyPath(Image.OpacityProperty));

            sb.Children.Add(fade_in);

            sb.Begin(advertisement);


        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            try
            {
                PRODUCT pdt = bt.DataContext as PRODUCT;
                //MessageBox.Show(pdt.id.ToString());
                CART cart = DataProvider.ins.DB.CARTs.Where(p => p.idCustomer == AccessUser.currentUser.id).FirstOrDefault();
                DateTime date = DateTime.Now;
                DateTime x = new DateTime(date.Year, date.Month, date.Day);
                //MessageBox.Show(x.ToString());
                String format = date.ToString("yyyy-MM-dd");

                //ORDER ord = new ORDER() { CART = cart, PRODUCT = pdt, quantity = 1, status = 0, date = date };
                //DataProvider.ins.DB.ORDERS.Add(ord);
                //Person person = DataProvider.ins.DB.PEOPLE.Find(2);
                //person.userName = "LaParka";
                //DataProvider.ins.DB.SaveChanges();
                ORDER order2 = DataProvider.ins.DB.ORDERS.Where(y => y.idProduct == pdt.id && y.idCart == cart.id  && y.status == 0).FirstOrDefault();
                if (order2 == null)
                {
                    string query = "INSERT ORDERS values(@cartid, @pdtid, 1, @date, 0)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cartid", cart.id);
                            cmd.Parameters.AddWithValue("@pdtid", pdt.id);
                            cmd.Parameters.AddWithValue("@date", format);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    DataProvider.Ins.DB.Notifications.Add(new Notification() { IDPEOPLE = AccessUser.currentUser.id, CHECKED = "Unseen", NOTIFY = "Add " + pdt.name + " to cart" });
                    DataProvider.Ins.DB.SaveChanges();
                    SucceedNotify succeedNotify = new SucceedNotify();
                    succeedNotify.ShowDialog();
                    MainViewModel.Instance.CurrentView = new CartViewModel();
                }
                else
                {
                    ValidationNotify failure = new ValidationNotify("You've already added this product to cart");
                    failure.ShowDialog();


                }


            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You fucking fool");
            }



        }

        private void AddtoCart_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            try
            {
                PRODUCT pdt = bt.DataContext as PRODUCT;
                //MessageBox.Show(pdt.id.ToString());
                CART cart = DataProvider.ins.DB.CARTs.Where(p => p.idCustomer == AccessUser.currentUser.id).FirstOrDefault();
                var date = DateTime.Now;
                DateTime x = new DateTime(date.Year, date.Month, date.Day);
                //MessageBox.Show(x.ToString());
                String format = date.ToString("yyyy-MM-dd");

                //ORDER ord = new ORDER() { CART = cart, PRODUCT = pdt, quantity = 1, status = 0, date = date };
                //DataProvider.ins.DB.ORDERS.Add(ord);
                //Person person = DataProvider.ins.DB.PEOPLE.Find(2);
                //person.userName = "LaParka";
                //DataProvider.ins.DB.SaveChanges();
                ORDER order2 = DataProvider.ins.DB.ORDERS.Where(y => y.idProduct == pdt.id && y.idCart == cart.id  && y.status == 0).FirstOrDefault();
                if(order2 == null)
                {
                    string query = "INSERT ORDERS values(@cartid, @pdtid, 1, @date, 0)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cartid", cart.id);
                            cmd.Parameters.AddWithValue("@pdtid", pdt.id);
                            cmd.Parameters.AddWithValue("@date", format);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    DataProvider.Ins.DB.Notifications.Add(new Notification() { IDPEOPLE = AccessUser.currentUser.id, CHECKED = "Unseen", NOTIFY = "Add " + pdt.name + " to cart"});
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    ValidationNotify failure = new ValidationNotify("You've already added this product to cart");
                    failure.ShowDialog();


                }


            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You fucking fool");
            }
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = 1;

            ListView x = sender as ListView;
            CATEGORY selectedItem = x.SelectedItem as CATEGORY;
            if (selectedItem != null)
            {
                AccessUser.searchWd = selectedItem.type;
                MainViewModel.Instance.CurrentView = new SearchFilterProductViewModel();
            }
            
        }

        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView x = sender as ListView;
            PRODUCT product = x.SelectedItem as PRODUCT;
            if(product != null)
            {
                MainViewModel.addViewToStack(new ProductDetailViewModel(product));


            }

        }
    }
}

