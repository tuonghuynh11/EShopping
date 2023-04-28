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
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        public PaymentOptions()
        {
            InitializeComponent();
            this.DataContext = ShippingAddressViewModel.Instance.CurrentView;
        }

        private void creditVisardbtn_Checked(object sender, RoutedEventArgs e)
        {
            creditcardFill.Visibility = Visibility.Visible ;
            continuebtn.Content = "Pay now";

        }

        private void creditVisardbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            creditcardFill.Visibility = Visibility.Collapsed;

        }

        private void creditAmericanrdbtn_Checked(object sender, RoutedEventArgs e)
        {
            americancardFill.Visibility = Visibility.Visible ;
            continuebtn.Content = "Pay now";
        }

        private void creditAmericanrdbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            americancardFill.Visibility=Visibility.Collapsed;
        }

        private void codpaymentbtn_Checked(object sender, RoutedEventArgs e)
        {
            continuebtn.Content = "Order";
        }
    }
}
