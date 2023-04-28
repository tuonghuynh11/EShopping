using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
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
using System.Windows.Shapes;
using E_Shopping.Model;

namespace E_Shopping
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private List<BitmapImage> Images = new List<BitmapImage>();
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        int t1;
        public Dashboard()
        {
            InitializeComponent();
            t1 = 0;
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/ad1.jpg")));
            Images.Add(new BitmapImage(new Uri("pack://application:,,,/image/ad2.jpg")));
            Advertisement.Source = Images[0];
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
            if (t1 == -1) { t1 = Images.Count - 1; }
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

           t1  = (t1 + 1)% Images.Count;
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
                MessageBox.Show(pdt.id.ToString());
                CART cart = DataProvider.ins.DB.CARTs.Where(p=>p.idCustomer == 2).FirstOrDefault();
                //ORDER ord = new ORDER() { id = 0, CART = cart, PRODUCT = pdt, quantity = 1, data = DateTime.Now, status = 1 };
                //ord.RECEIPTs.Add(new RECEIPT() { idCustomer = 2 });

                //DataProvider.ins.DB.ORDERS.Add(ord);
                //Person person = DataProvider.ins.DB.PEOPLE.Find(2);
                //person.userName = "Dean";
                //DataProvider.ins.DB.SaveChanges();


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
                MessageBox.Show(pdt.id.ToString());
                CART cart = DataProvider.ins.DB.CARTs.Where(p => p.idCustomer == 2).FirstOrDefault();
                var date = DateTime.Now;
                DateTime x = new DateTime(date.Year, date.Month, date.Day);
                MessageBox.Show(x.ToString());
                String format = date.ToString("yyyy-MM-dd");
                CATEGORY cat = new CATEGORY() { type = "Pet" };

                ORDER ord = new ORDER() { };
                DataProvider.ins.DB.ORDERS.Add(ord);
                DataProvider.ins.DB.SaveChanges();
                Person person = DataProvider.ins.DB.PEOPLE.Find(2);
                person.userName = "LaParka";
                DataProvider.ins.DB.SaveChanges();
                //string query = "INSERT ORDERS values(@cartid, @pdtid, 1, @date, 0)";
                //using(SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    using(SqlCommand cmd = new SqlCommand(query, conn))
                //    {
                //        cmd.Parameters.AddWithValue("@cartid", cart.id);
                //        cmd.Parameters.AddWithValue("@pdtid", pdt.id);
                //        cmd.Parameters.AddWithValue("@date", format);
                //        conn.Open();
                //        cmd.ExecuteNonQuery();
                //        conn.Close();
                //    }
                //}
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You fucking fool");
            }
        }
    }
}
