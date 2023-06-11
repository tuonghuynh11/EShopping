using E_Shopping.Model;
using E_Shopping.PopUp;
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

namespace E_Shopping
{
    /// <summary>
    /// Interaction logic for AddNewGiftCode.xaml
    /// </summary>
    public partial class AddNewGiftCode : Window
    {
        public int idCustomer { get; set; }
        public AddNewGiftCode()
        {
            InitializeComponent();
        }
        public AddNewGiftCode(int idCustomer)
        {
            InitializeComponent();
            this.idCustomer = idCustomer;
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {

            if (newCodetb.Text.ToString()=="")
            {
                ValidationNotify validation = new ValidationNotify("Code is empty");
                validation.ShowDialog();
                return;
            }
            else if (discountValuetb.Text.ToString()=="")
            {
                ValidationNotify validation = new ValidationNotify("Discount value is empty");
                validation.ShowDialog();
                return;
            }
            else if (expDate.SelectedDate==null)
            {
                ValidationNotify validation = new ValidationNotify("Expire day is empty");
                validation.ShowDialog();
                return;
            }


            String newCode = newCodetb.Text.ToString();
            
            int number;
            if (!int.TryParse(discountValuetb.Text.ToString(),out number))
            {
                ValidationNotify validation = new ValidationNotify("Discount value musts number");
                validation.ShowDialog();
                return;
            }
            int percent = int.Parse(discountValuetb.Text.ToString());

            DateTime exp = expDate.SelectedDate.Value;
            if (expDate.SelectedDate.Value< DateTime.Today)
            {
                ValidationNotify validation = new ValidationNotify("Expire day shouldn't less than today");
                validation.ShowDialog();
                return;
            }

           DataProvider.ins.db.DISCOUNTs.Add(new DISCOUNT() { idCustomer= this.idCustomer,code =newCode, value= percent, exp_time= exp ,status="Unused" });
            DataProvider.ins.db.SaveChanges();

            this.Close();
            SucceedNotify succeed = new SucceedNotify();
            succeed.Show();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void generateCode_Click(object sender, RoutedEventArgs e)
        {
            newCodetb.Text = generateID();
        }
    }
}
