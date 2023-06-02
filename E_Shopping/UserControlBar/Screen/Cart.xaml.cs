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

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {
        //List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
        public Cart()
        {
            InitializeComponent();
            //(this.DataContext as CartViewModel).calculateSubTotal();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (ORDER item in CartView.Items)
            {
                item.check = true;
            }
             (this.DataContext as CartViewModel).calculateSubTotal();
            CartView.Items.Refresh();
        }
        private void UnheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (ORDER item in CartView.Items)
            {
                item.check = false;
            }
             (this.DataContext as CartViewModel).calculateSubTotal();
            CartView.Items.Refresh();
        }


        private void increase_Click(object sender, RoutedEventArgs e)
        {
            ORDER shoppingCart = CartView.SelectedItem as ORDER;
            shoppingCart.quantity++;

            DataProvider.ins.DB.SaveChanges();
            MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Find(shoppingCart.idProduct);

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

            CartView.Items.Refresh();
            (this.DataContext as CartViewModel).calculateSubTotal();
        }

        private void decrease_Click(object sender, RoutedEventArgs e)
        {
            ORDER shoppingCart = CartView.SelectedItem as ORDER;
            MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Find(shoppingCart.idProduct);

            if (shoppingCart.quantity != 1)
            {
                shoppingCart.quantity--;
                available_quantiy.quantity++;
                DataProvider.ins.DB.SaveChanges();
                CartView.Items.Refresh();
            }
            (this.DataContext as CartViewModel).calculateSubTotal();

        }

        private void clearShoppingCartbtn_Click(object sender, RoutedEventArgs e)
        {
            CartView.UnselectAll();
            CartViewModel cartViewModel = this.DataContext as CartViewModel;


            foreach (ORDER item in cartViewModel.shoppingCarts)
            {
                MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Find(item.idProduct);
                available_quantiy.quantity += item.quantity;
                DataProvider.ins.DB.SaveChanges();
            }

            cartViewModel.shoppingCarts.Clear();
            (this.DataContext as CartViewModel).calculateSubTotal();

        }

        private void isBuy_Checked(object sender, RoutedEventArgs e)
        {
            if (CartView.SelectedItem != null)
            {
                (CartView.SelectedItem as ORDER).check = true;
                (this.DataContext as CartViewModel).calculateSubTotal();
            }

        }

        private void isBuy_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CartView.SelectedItem != null)
            {
                (CartView.SelectedItem as ORDER).check = false;
                (this.DataContext as CartViewModel).calculateSubTotal();
            }

        }

        private void deleteItembtn_Click(object sender, RoutedEventArgs e)
        {
            CartViewModel cartViewModel = this.DataContext as CartViewModel;
            ORDER shoppingCart = (ORDER)CartView.SelectedItem;
            MANAGEPRODUCTSYSTEM available_quantiy = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Find(shoppingCart.idProduct);
            available_quantiy.quantity += shoppingCart.quantity;
            cartViewModel.shoppingCarts.Remove(shoppingCart);
            DataProvider.ins.DB.ORDERS.Remove(shoppingCart);
            DataProvider.ins.DB.SaveChanges();
            (this.DataContext as CartViewModel).calculateSubTotal();
        }
    }
}
