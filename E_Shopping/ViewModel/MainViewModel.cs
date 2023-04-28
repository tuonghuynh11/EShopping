using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public bool IsLoad = false;
        public ICommand LoadedWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                IsLoad = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsClose)
                {

                    p.Close();
                }
                if (loginVM.IsLogin)
                {

                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });



        }
    }
}
