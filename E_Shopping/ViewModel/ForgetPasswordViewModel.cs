using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.WebRequestMethods;
using System.Windows.Controls;
using E_Shopping.Model;
using E_Shopping.PasswordEncode;

namespace E_Shopping.ViewModel
{
    public class ForgetPasswordViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand OTPSendCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand rePasswordChangedCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        private int otp;

        private string _userName;
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        private string _OTP;
        public string OTP { get => _OTP; set { _OTP = value; OnPropertyChanged(); } }

        private string _passWord;
        public string PassWord { get => _passWord; set { _passWord = value; OnPropertyChanged(); } }

        private string _repassWord;
        public string rePassWord { get => _repassWord; set { _repassWord = value; OnPropertyChanged(); } }
        public ForgetPasswordViewModel()
        {
            Random random = new Random();
            
            UserName = "";
            PassWord = "";
            rePassWord = "";
            OTP = "";
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                UserName = "";
                OTP = "";
            });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            OTPSendCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                otp = random.Next(100000, 1000000);
                if (IsMailValid(UserName))
                {
                    try
                    {

                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("eshoppingprojectcnpm@gmail.com");
                        msg.To.Add(UserName);

                        msg.Subject = "OTP for forget password confirmation";
                        msg.Body = otp.ToString() + " is the code to confirm password re-creation.";

                        SmtpClient smt = new SmtpClient();
                        smt.Host = "smtp.gmail.com";
                        System.Net.NetworkCredential ntcd = new NetworkCredential();
                        ntcd.UserName = "eshoppingprojectcnpm@gmail.com";
                        ntcd.Password = "skczhwysbwxkwfxy";
                        smt.Credentials = ntcd;
                        smt.EnableSsl = true;
                        smt.Port = 587;
                        smt.Send(msg);

                        MessageBox.Show("Succeeded");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed");

                    }
                }
                // add else if for phone verification
                else
                {
                    MessageBox.Show("Not valid");
                }
                
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PassWord = p.Password; });
            rePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { rePassWord = p.Password; });
            OKCommand = new RelayCommand<Window>((p) => {
                if (string.IsNullOrEmpty(UserName))
                    return false;
                var userList = DataProvider.ins.db.PEOPLE.Where(x => x.userName == UserName);
                if(userList == null || userList.Count() == 0)
                    return false;
                return true; 
            }, (p) => { 
                if(UserName != "" && PassWord != "" && PassWord == rePassWord && otp.ToString() == OTP)
                {
                    var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == UserName).SingleOrDefault();
                    user.password = EncodeString.EncodePass(PassWord);
                    DataProvider.ins.db.SaveChanges();
                    MessageBox.Show("Done");
                    p.Close();
                }
                else
                {
                    otp = -1;
                    MessageBox.Show("Not done");
                }
            });
        }
        public bool IsMailValid(string emailaddress)
        {
            if(emailaddress == "")
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
