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
    /// Interaction logic for DeliveryOption.xaml
    /// </summary>
    public partial class DeliveryOption : UserControl
    {
        public DeliveryOption()
        {
            InitializeComponent();
            this.DataContext = ShippingAddressViewModel.Instance.CurrentView;

        }

        private void freeshiprdbtn_Checked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DeliveryOptionViewModel).changeShippingFee();
        }

        private void expressshiprdbtn_Checked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DeliveryOptionViewModel).changeShippingFee();

        }

        private void SuperExpressShiprdbtn_Checked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DeliveryOptionViewModel).changeShippingFee();

        }
    }
}
