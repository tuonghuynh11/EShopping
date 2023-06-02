using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using E_Shopping.Model;
using E_Shopping.PasswordEncode;
using E_Shopping.PopUp;

namespace E_Shopping.ViewModel
{
    public class ChangePassViewModel:BaseViewModel
    {

        private int otp;
        public ICommand CloseCommand { get; set; }
        public ICommand OTPSendCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand oldPasswordChangedCommand { get; set; }
        public ICommand newPasswordChangedCommand { get; set; }
        public ICommand rePasswordChangedCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        private string _OTP;
        public string OTP { get => _OTP; set { _OTP = value; OnPropertyChanged(); } }

        private string _oldpassWord;
        public string oldPassWord { get => _oldpassWord; set { _oldpassWord = value; OnPropertyChanged(); } }

        private string _newpassWord;
        public string newPassWord { get => _newpassWord; set { _newpassWord = value; OnPropertyChanged(); } }

        private string _repassWord;
        public string rePassWord { get => _repassWord; set { _repassWord = value; OnPropertyChanged(); } }

        public ChangePassViewModel()
        {
            Random random = new Random();

            oldPassWord = "";
            newPassWord = "";
            rePassWord = "";
            OTP = "";
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                OTP = "";
            });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            OTPSendCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                otp = random.Next(100000, 1000000);
                if (IsMailValid(LoginViewModel.AppUser))
                {
                    try
                    {

                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("shopgo870@gmail.com");
                        msg.To.Add(LoginViewModel.AppUser);

                        msg.Subject = "OTP for forget password confirmation";
                        msg.Body = otp.ToString() + " is the code to confirm password re-creation.";

                        SmtpClient smt = new SmtpClient();
                        smt.Host = "smtp.gmail.com";
                        System.Net.NetworkCredential ntcd = new NetworkCredential();
                        ntcd.UserName = "shopgo870@gmail.com";
                        ntcd.Password = "jkotoxlrmbqchpqu";
                        smt.Credentials = ntcd;
                        smt.EnableSsl = true;
                        smt.Port = 587;
                        smt.Send(msg);

                        SucceedNotify succeedNotify = new SucceedNotify();
                        succeedNotify.ShowDialog();

                    }
                    catch (Exception)
                    {
                        ValidationNotify validationNotify = new ValidationNotify("Failed to send OTP");
                        validationNotify.ShowDialog();


                    }
                }
                // add else if for phone verification
                else
                {
                    ValidationNotify validationNotify = new ValidationNotify("Invalid Email");
                    validationNotify.ShowDialog();
                }

            });
            oldPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { oldPassWord = p.Password; });
            newPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { newPassWord = p.Password; });
            rePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { rePassWord = p.Password; });
            OKCommand = new RelayCommand<Window>((p) => {
                if (string.IsNullOrEmpty(LoginViewModel.AppUser))
                    return false;
                var userList = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser);
                if (userList == null || userList.Count() == 0)
                    return false;
                return true;
            }, (p) => {
                
                var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
                if (LoginViewModel.AppUser != "" && newPassWord != "" && newPassWord == rePassWord && otp.ToString() == OTP && user.password == EncodeString.EncodePass(oldPassWord))
                {
                    user.password = EncodeString.EncodePass(newPassWord);
                    DataProvider.ins.db.SaveChanges();
                    SucceedNotify succeedNotify = new SucceedNotify();
                    succeedNotify.ShowDialog();
                    p.Close();
                }
                else
                {
                    otp = -1;
                    ValidationNotify validationNotify = new ValidationNotify("Failed to change password");
                    validationNotify.ShowDialog();
                }
            });
        }
        public bool IsMailValid(string emailaddress)
        {
            if (emailaddress == "")
            {
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
