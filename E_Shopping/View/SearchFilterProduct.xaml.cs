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
using E_Shopping.Class;
using E_Shopping.ViewModel;

namespace E_Shopping.View
{
    /// <summary>
    /// Interaction logic for SearchFilterProduct.xaml
    /// </summary>
    public partial class SearchFilterProduct : UserControl
    {
        public static SearchFilterProductViewModel _searchFilterProductViewModel { get; set; }

        public SearchFilterProduct()
        {
            InitializeComponent();
            this.DataContext = _searchFilterProductViewModel = new SearchFilterProductViewModel();
            //this.DataContext = MainViewModel.Instance.CurrentView;

        }
    }
}
