using E_Shopping.Model;
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
using System.Windows.Shapes;

namespace E_Shopping.PopUp
{
    /// <summary>
    /// Interaction logic for RateProduc.xaml
    /// </summary>
    public partial class RateProduc : Window
    {
        int load = 0;
        public int idCustomer;
        public ORDER product;
        public RateProduc()
        {
            InitializeComponent();
        }
        public RateProduc(int idCustomer, ORDER product) 
        {

            InitializeComponent();
            this.idCustomer = idCustomer;
            this.product = product;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTRATE productRate= new PRODUCTRATE() { idCustomer=this.idCustomer,idProduct=this.product.id,rate= int.Parse(RatingBar.Value.ToString())};
            DataProvider.ins.DB.PRODUCTRATEs.Add(productRate);
            DataProvider.ins.DB.SaveChanges();
            this.Close();
        }

        private void rateLaterbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void RatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (load!=1)
            {
                return;
            }
           double value = e.NewValue;
            if (value>=3)
            {
                describeRatelb.Text = "That's great, to hear you are satisfied with the product";
            }
            else
            {
                describeRatelb.Text = "Sorry, we can definitely see how frustrating you would be";
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load = 1;
        }
    }
}
