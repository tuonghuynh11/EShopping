using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.Untils;
using E_Shopping.UserControlBar.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class ShippingDetailsViewModel:BaseViewModel
    {
        public ICommand ContinueToDeliveryOptions { get; set; }
        public ICommand UseProfileInformationCommand { get; set; }
        
        public static RECEIVERINFORMATION receiverInfo { get; set; }

        //notify
        public ValidationNotify validationNotify ;

        //Attribute
        private string _firstNanme;
        public string firstNanme { get => _firstNanme; set { _firstNanme = value; OnPropertyChanged(); } }

        private string _lastNanme;
        public string lastNanme { get => _lastNanme; set { _lastNanme = value; OnPropertyChanged(); } }

        private string _email;
        public string email { get => _email; set { _email = value; OnPropertyChanged(); } }

        private string _phoneNumber;
        public string phoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }

        private string _address;
        public string address { get => _address; set { _address = value; OnPropertyChanged(); } }

        private string _note;
        public string note { get => _note; set { _note = value; OnPropertyChanged(); } }


        public ShippingDetailsViewModel()
        {
            UseProfileInformationCommand = new RelayCommand<ShippingDetails>((p) =>
            {
                return true;
            }, (p) =>
            {
                
                PEOPLEINFO peopleInfo = DataProvider.ins.DB.PEOPLEINFOes.Where(v=>v.idCustomer== AccessUser.currentUser.id).FirstOrDefault();
                if (peopleInfo!=null)
                {
                    RECEIVERINFORMATION receiver = DataProvider.ins.DB.RECEIVERINFORMATIONs.Find(peopleInfo.idReceiverInfo);
                    String[] name = receiver.name.Split(' ');
                    firstNanme = name[0];
                    lastNanme = "";
                    for (int i = 1; i < name.Length; i++)
                    {
                        lastNanme+=name[i];
                    }
                    email = receiver.email;
                    address = receiver.address;
                    phoneNumber = receiver.phoneNumber;
                }
                else
                {
                    ValidationNotify validationNotify = new ValidationNotify("Profile Information is empty!!");
                    validationNotify.ShowDialog();
                }
            });

           ContinueToDeliveryOptions = new RelayCommand<ShippingDetails>((p) =>
            {
                return true;
            }, async (p) =>
            {
                if (p.contactfirstNametb.Text == null||p.contactfirstNametb.Text=="")
                {
                    validationNotify = new ValidationNotify("First name can't empty!!");
                    validationNotify.ShowDialog();
                    return;
                }
                else if (p.contactlastNametb.Text == null|| p.contactlastNametb.Text == "")
                {
                    validationNotify = new ValidationNotify("Last name can't empty!!");
                    validationNotify.ShowDialog();
                    return;

                }
                else if (p.contactphonetb.Text == null|| p.contactphonetb.Text == "")
                {
                    validationNotify = new ValidationNotify("Phone number can't empty!!");
                    validationNotify.ShowDialog();
                    return;

                }
                else if (p.contactphonetb.Text != null || p.contactphonetb.Text != "")
                {
                    if (!VnPhoneNumberValidator.VnPhoneNumberIsValid(p.contactphonetb.Text))
                    {
                        validationNotify = new ValidationNotify("Phone Number invalid!!");
                        validationNotify.ShowDialog();
                        return;
                    }
                    else
                    {
                        if (p.shippingAddresstb.Text == null || p.shippingAddresstb.Text == "")
                        {
                            validationNotify = new ValidationNotify("Address can't empty!!");
                            validationNotify.ShowDialog();
                            return;
                        }
                        else
                        {
                            if (p.contactEmailtb.Text != "")
                            {
                                if (!EmailValidator.EmailIsValid(p.contactEmailtb.Text))
                                {
                                    validationNotify = new ValidationNotify("Email invalid!!");
                                    validationNotify.ShowDialog();
                                    return;
                                }
                            }
                        }
                    }
                }
                receiverInfo = new RECEIVERINFORMATION() { name=firstNanme +" "+ lastNanme,address=address,email=email,note=note,phoneNumber= phoneNumber};

                ProgressBar progressBar = new ProgressBar();
                progressBar.Show();

                var distance = await DistanceCalculate.GetDistance("Đường Hàn Thuyên, khu phố 6 P, Thủ Đức, Thành phố Hồ Chí Minh", p.shippingAddresstb.Text);
                progressBar.Close();
                ShippingAddressViewModel.addViewToStack(distance) ;

            });
        }


    }
}
