using E_Shopping.Model;
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

namespace E_Shopping.View
{
    /// <summary>
    /// Interaction logic for SearchFilterProduct.xaml
    /// </summary>
    public partial class SearchFilterProduct : UserControl
    {
        public SearchFilterProduct(/*string searchValue*/)
        {
            InitializeComponent();
            this.DataContext = MainViewModel.Instance.CurrentView;
        }

        private void checkText(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxMin.Text, "^[0-9]*$"))
            {
                TextBoxMin.Text = string.Empty;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxMax.Text, "^[0-9]*$"))
            {
                TextBoxMax.Text = string.Empty;
            }
        }

        private void ListViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PRODUCTWRAPPER product = ListViewProducts.SelectedItems[0] as PRODUCTWRAPPER;
            if (product != null)
            {
                MainViewModel.Instance.CurrentView = new ProductDetailViewModel(product.Product);
                MainViewModel.stackView.Push(MainViewModel.Instance.CurrentView);
            }
        }

    }
}
