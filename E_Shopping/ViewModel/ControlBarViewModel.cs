using E_Shopping.Class;
using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
namespace E_Shopping.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {

        #region comands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand PartyInTheUSA { get; set; }
        public ICommand FeedBackClick { get; set; }
        public ICommand CartClick { get; set; }


        #endregion


        public ControlBarViewModel()
        {

            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) => {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }

                });
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) => {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.WindowState = WindowState.Minimized;
                    }

                });
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) => {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.DragMove();
                    }

                });
            PartyInTheUSA = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    System.Diagnostics.Process.Start("http://www.wwe.com");

                });
            FeedBackClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    //ChatBoxScreen chatBoxScreen = new ChatBoxScreen();
                    //chatBoxScreen.ShowDialog();

                    //ObservableCollection<ORDER> buyingList = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(e => (e.status == 1 || e.status == 2) && e.idCart == AccessUser.currentUser.idCart));
                    //buyingList[0].status = 3;
                    //DataProvider.ins.DB.SaveChanges();
                    Feedback feedBack = new Feedback();
                    feedBack.Show();
                });
            CartClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    MainViewModel.Instance.CurrentView = new CartViewModel();
                });
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {

                parent = parent.Parent as FrameworkElement;

            }
            return parent;
        }

    }
}
