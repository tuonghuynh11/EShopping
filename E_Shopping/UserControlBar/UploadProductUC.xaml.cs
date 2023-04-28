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

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for UploadProductUC.xaml
    /// </summary>
    public partial class UploadProductUC : UserControl
    {
        public UploadProductUC()
        {
            InitializeComponent();
        }

        private void oldRad_Checked(object sender, RoutedEventArgs e)
        {
            newCateTxb.IsEnabled = false;
            newCateTxb.IsHitTestVisible = false;
            CateCB.IsHitTestVisible = true;
            CateCB.IsEnabled = true;

        }

        private void newRad_Checked(object sender, RoutedEventArgs e)
        {
            newCateTxb.IsEnabled = true;
            newCateTxb.IsHitTestVisible = true;
            CateCB.IsHitTestVisible = false;
            CateCB.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txbName.Text = "";
            txbPrice.Text = "";
            txbFunc.Text = "";
            txbMaterial.Text = "";
            txbProDes.Text = "";
            txbWanTime.Text = "";
            txbProName.Text = "";
            newCateTxb.Text = "";
            CateCB.Text = "";
            newRad.IsChecked = false;
            oldRad.IsChecked = false;
            newCateTxb.IsEnabled = false;
            newCateTxb.IsHitTestVisible = false; 
            CateCB.IsHitTestVisible = false;
            CateCB.IsEnabled = false;
        }
    }
}
