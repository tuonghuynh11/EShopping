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
    /// Interaction logic for ValidationNotify.xaml
    /// </summary>
    public partial class ValidationNotify : Window
    {
        public ValidationNotify()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public ValidationNotify(string a)
        {
            InitializeComponent();
            content.Text = a;
        }
    }
}
