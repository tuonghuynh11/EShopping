using E_Shopping.Model;
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
    /// Interaction logic for UserAccountDetail.xaml
    /// </summary>
    public partial class UserAccountDetail : Window
    {
        Person selectedPerson;
        public UserAccountDetail(Person person)
        {
            InitializeComponent();
            ID.Text = person.id.ToString();
            Username.Text = person.userName;
            Name.Text = person.name;
            Gender.Text = person.gender;
            phoneNum.Text = person.phoneNumber;
            email.Text = person.email;
            Address.Text = person.address;
            string temp = person.birthday.ToString();
            if(temp != "")
                Dob.Text = temp.Substring(0, temp.IndexOf(' '));
            selectedPerson = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var updatePerson = DataProvider.ins.db.PEOPLE.Where(p => p.id == selectedPerson.id).SingleOrDefault();
            if(updatePerson != null)
            {
                updatePerson.idRole = 2;
                DataProvider.ins.db.SaveChanges();
                MessageBox.Show("Staff done");
            }
        }

        //Ban account can phai them 1 cai gi do de phan biet(chua lam)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
