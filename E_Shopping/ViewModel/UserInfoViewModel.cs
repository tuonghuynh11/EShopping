using E_Shopping.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace E_Shopping.ViewModel
{
    public class UserInfoViewModel:BaseViewModel
    {
        //Them column gender vo database
        public ObservableCollection<string> GenderList { get; private set; }
        public ObservableCollection<string> CardList { get; private set; }

        private String _displayedImagePath;
        public String DisplayedImagePath { get => _displayedImagePath; set { _displayedImagePath = value; OnPropertyChanged(); } }

        

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _dob;
        public string DOB { get => _dob; set { _dob = value; OnPropertyChanged(); } }

        private string _address;
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }

        private string _gender;
        public string Gender { get => _gender; set { _gender = value; OnPropertyChanged(); } }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

        private string _cardType;
        public string CardType { get => _cardType; set { _cardType = value; OnPropertyChanged(); } }

        private string _cardNum;
        public string CardNum { get => _cardNum; set { _cardNum = value; OnPropertyChanged(); } }

        private string _selectedGender;
        public string SelectedGender { get => _selectedGender; set { _selectedGender = value; OnPropertyChanged(); } }

        private string _selectedCardType;
        public string SelectedCardType { get => _selectedCardType; set { _selectedCardType = value; OnPropertyChanged(); } }

        private DateTime _selectedDate;
        public DateTime SelectedDate { get => _selectedDate; set { _selectedDate = value; OnPropertyChanged(); } }
        public ICommand TestCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UploadCommand { get; set; }
        public UserInfoViewModel()
        {
            GenderList = new ObservableCollection<string>
            {
                "Male",
                "Female"
            };
            CardList = new ObservableCollection<string>
            {
                "VISA",
                "MasterCard",
                "American Express"
            };
            TestCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MessageBox.Show("test done"); });
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
                if(user != null)
                {
                    if(user.avatar != null)
                    {

                        DisplayedImagePath = user.avatar;
                        

                    }
                    else
                    {
                        DisplayedImagePath = @"/Image/Avatar.jpeg";
                        
                    }
                    if(user.name != null)
                        Name = user.name;
                    if(user.birthday != null)
                    {
                        SelectedDate = (DateTime)user.birthday;
                        string tempDoB = user.birthday.ToString();
                        if (tempDoB != "")
                            DOB = tempDoB.Substring(0, tempDoB.IndexOf(' '));

                    }
                    else
                    {
                        SelectedDate = DateTime.Now;
                    }
                    if(user.address != null)
                        Address = user.address;
                    if(user.gender != null)
                    {

                        Gender = user.gender;
                        SelectedGender = user.gender;
                    }
                    if(user.phoneNumber != null)
                        PhoneNumber = user.phoneNumber;
                    if(user.email != null)
                        Email = user.email;
                    //Them id cua person vo paymentinfomation
                    var card = DataProvider.ins.db.PAYMENTINFORMATIONs.Where(x => x.idPerson == user.id).SingleOrDefault();
                    
                    if(card != null)
                    {

                        CardNum = card.cardNumber;
                        var type = DataProvider.ins.db.CREDITCARDs.Where(x => x.id == card.typeOfCard).SingleOrDefault();
                        if (type != null)
                        {


                            CardType = type.type_name;
                            SelectedCardType = type.type_name;
                        }
                    }
                    
                }
            });

            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
                if (user != null)
                {
                    if (user.name != null)
                        Name = user.name;
                    if (user.birthday != null)
                    {
                        SelectedDate = (DateTime)user.birthday;
                        string tempDoB = user.birthday.ToString();
                        if (tempDoB != "")
                            DOB = tempDoB.Substring(0, tempDoB.IndexOf(' '));

                    }
                    else
                    {
                        SelectedDate = DateTime.Now;
                    }
                    if (user.address != null)
                        Address = user.address;
                    if (user.gender != null)
                    {

                        Gender = user.gender;
                        SelectedGender = user.gender;
                    }
                    if (user.phoneNumber != null)
                        PhoneNumber = user.phoneNumber;
                    if (user.email != null)
                        Email = user.email;
                    //Them id cua person vo paymentinfomation
                    var card = DataProvider.ins.db.PAYMENTINFORMATIONs.Where(x => x.idPerson == user.id).SingleOrDefault();

                    if (card != null)
                    {

                        CardNum = card.cardNumber;
                        var type = DataProvider.ins.db.CREDITCARDs.Where(x => x.id == card.typeOfCard).SingleOrDefault();
                        if (type != null)
                        {


                            CardType = type.type_name;
                            SelectedCardType = type.type_name;
                        }
                    }

                }
            });
            SaveCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
                if(user != null)
                {
                    user.name = Name;
                    user.birthday = SelectedDate;
                    user.address = Address;
                    user.gender = SelectedGender;
                    user.phoneNumber = PhoneNumber;
                    user.email = Email;
                    var card = DataProvider.ins.db.PAYMENTINFORMATIONs.Where(x => x.idPerson == user.id).SingleOrDefault();
                    if(card != null)
                    {

                        var type = DataProvider.ins.db.CREDITCARDs.Where(x => x.type_name == SelectedCardType).SingleOrDefault();
                        card.cardNumber = CardNum;
                        CardType = SelectedCardType;
                        if(type != null)
                            card.typeOfCard = type.id;
                        
                    }
                    DataProvider.ins.db.SaveChanges();

                    Name = user.name;
                    SelectedDate = (DateTime)user.birthday;
                    string tempDoB = user.birthday.ToString();
                    if (tempDoB != "")
                        DOB = tempDoB.Substring(0, tempDoB.IndexOf(' '));
                    Address = user.address;
                    Gender = user.gender;
                    SelectedGender = user.gender;
                    PhoneNumber = user.phoneNumber;
                    Email = user.email;
                    var card2 = DataProvider.ins.db.PAYMENTINFORMATIONs.Where(x => x.idPerson == user.id).SingleOrDefault();
                    if (card2 != null)
                    {

                        var type2 = DataProvider.ins.db.CREDITCARDs.Where(x => x.id == card.typeOfCard).SingleOrDefault();
                        CardNum = card2.cardNumber;
                        if(type2 != null)
                        {
                            CardType = type2.type_name;
                            SelectedCardType = type2.type_name;

                        }
                    }
                    //MessageBox.Show("Da save");
                }
            });
            UploadCommand = new RelayCommand<object>((p) => { return true; }, (p) => { 
                
            });
        }
    }
}
