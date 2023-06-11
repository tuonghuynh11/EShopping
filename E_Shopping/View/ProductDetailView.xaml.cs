using E_Shopping.Model;
using E_Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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
using static System.Net.WebRequestMethods;

namespace E_Shopping.View
{
    /// <summary>
    /// Interaction logic for ProductDetailView.xaml
    /// </summary>
    public partial class ProductDetailView : UserControl
    {
        private int quantity = ProductDetailViewModel.QuantityProduct;
        public ProductDetailView()
        {
            InitializeComponent();
            this.DataContext = MainViewModel.Instance.CurrentView;
        }
        private void checkText(object sender, TextChangedEventArgs e)
        {
            if ((TextBoxQuantity.Text == null || TextBoxQuantity.Text.Equals("")) || (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxQuantity.Text, "^[1-9]*$")))
            {
                TextBoxQuantity.Text = "1";
            }
            else if (Int32.Parse(TextBoxQuantity.Text) > quantity)
            {
                TextBoxQuantity.Text = quantity.ToString();
            }
        }
    }
}
