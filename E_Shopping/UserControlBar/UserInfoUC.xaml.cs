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
    /// Interaction logic for UserInfoUC.xaml
    /// </summary>
    public partial class UserInfoUC : UserControl
    {
        public UserInfoUC()
        {
            InitializeComponent();
        }

        private void Editbtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Visible;
            Cancelbtt.Visibility = Visibility.Visible;
            Editbtt.Visibility = Visibility.Hidden;
            Nametb.IsReadOnly = false;
            addresstb.IsReadOnly = false;
            Phonetb.IsReadOnly = false;
            Emailtb.IsReadOnly = false;
            CardNumtb.IsReadOnly = false;
            cardTypetb.Visibility = Visibility.Hidden;
            cbCardType.Visibility = Visibility.Visible;
            genderTB.Visibility = Visibility.Hidden;
            cbGender.Visibility = Visibility.Visible;
            dpDob.Visibility = Visibility.Visible;
            dobtb.Visibility = Visibility.Hidden;
        }

        private void Cancelbtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Hidden;
            Cancelbtt.Visibility = Visibility.Hidden;
            Editbtt.Visibility = Visibility.Visible;
            Nametb.IsReadOnly = true;
            addresstb.IsReadOnly = true;
            Phonetb.IsReadOnly = true;
            Emailtb.IsReadOnly = true;
            CardNumtb.IsReadOnly = true;
            cardTypetb.Visibility = Visibility.Visible;
            cbCardType.Visibility = Visibility.Hidden;
            genderTB.Visibility = Visibility.Visible;
            cbGender.Visibility = Visibility.Hidden;
            dpDob.Visibility = Visibility.Hidden;
            dobtb.Visibility = Visibility.Visible;
        }

        private void Savebtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Hidden;
            Cancelbtt.Visibility = Visibility.Hidden;
            Editbtt.Visibility = Visibility.Visible;
            Nametb.IsReadOnly = true;
            addresstb.IsReadOnly = true;
            Phonetb.IsReadOnly = true;
            Emailtb.IsReadOnly = true;
            CardNumtb.IsReadOnly = true;
            cardTypetb.Visibility = Visibility.Visible;
            cbCardType.Visibility = Visibility.Hidden;
            genderTB.Visibility = Visibility.Visible;
            cbGender.Visibility = Visibility.Hidden;
            dpDob.Visibility = Visibility.Hidden;
            dobtb.Visibility = Visibility.Visible;
        }
    }
}
