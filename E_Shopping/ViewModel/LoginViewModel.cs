using E_Shopping.Model;
using E_Shopping.PasswordEncode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
   
    public class LoginViewModel:BaseViewModel
    {
        public static string AppUser;
        public bool IsLogin { get; set; }
        public bool IsClose { get; set; }
        private string _userName;
        private bool _isChecked;
        public bool IsChecked { get => _isChecked; set { _isChecked = value; OnPropertyChanged(); } }
        public string UserName { get => _userName;  set { _userName = value; OnPropertyChanged(); } }
        private string _passWord;
        public string PassWord { get => _passWord; set { _passWord = value; OnPropertyChanged(); } }
        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ForgetPasswordCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        public LoginViewModel()
        {
            IsLogin = false;
            IsClose = false;
            PassWord = "";
            UserName = "";
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { 
                if(Properties.Settings.Default.username != string.Empty)
                {
                    UserName = Properties.Settings.Default.username;
                    // Don't know how to give value for the passwordbox
                    
                }
            });

            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Close(p); });

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PassWord = p.Password; });
            ForgetPasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                ForgetPassword forgetPassword = new ForgetPassword();
                forgetPassword.ShowDialog();
            });
            RegisterCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                
                SignupWindow signupWindow = new SignupWindow();
                signupWindow.Show();
                if (signupWindow.DataContext == null)
                    return;
                
            });
        }
        void Close(Window p)
        {
            if (p == null)
                return;
            IsClose = true;
            p.Close();
        }
        void Login(Window p)
        {
            if (p == null)
                return;
            

            //Check if username and password are correct
            string passEncode = EncodeString.EncodePass(PassWord);
            var account = DataProvider.ins.db.PEOPLE.Where(user=>user.userName == UserName && user.password == passEncode).Count();
            if(account > 0)
            {
                IsLogin = true;
                if (IsChecked && UserName != "" && PassWord != "")
                {
                    Properties.Settings.Default.username = UserName;
                    Properties.Settings.Default.passWord = PassWord;
                    Properties.Settings.Default.Save();
                }
                AppUser = UserName;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("sai");
            }
        }
    }
}
