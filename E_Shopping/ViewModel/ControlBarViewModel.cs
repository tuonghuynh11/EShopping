using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.UserControlBar;
using E_Shopping.View;
using Stripe;
using Stripe.Radar;

namespace E_Shopping.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        ObservableCollection<Notification> notifies;
        public ObservableCollection<Notification> Notifies { get { return notifies; } set { notifies = value; OnPropertyChanged(); } }
        int uncheck;
        public int Uncheck
        {
            get { return uncheck; }
            set
            {
                uncheck = value;
                OnPropertyChanged();
            }
        }
        string notePopUp = "Bạn có 0 thông báo mới";
        public string NotifyPopUp
        {
            get { return notePopUp; }
            set { notePopUp = value; OnPropertyChanged(); }
        }
        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value;  OnPropertyChanged(); }
        }
         string searchWd;
        public string SearchWD
        {
            get { return searchWd; }
            set { searchWd = value; OnPropertyChanged(); }
        }
        private string avatar;
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; OnPropertyChanged(); }
        }
        
        #region comands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand PartyInTheUSA { get; set; }
        public ICommand FeedBackClick { get; set; }
        public ICommand CartClick { get; set; }
        public ICommand IconClick { get; set; }

        public ICommand VisibleCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand PopUpOpened { get; set; }
        #endregion


        public ControlBarViewModel()
        {
            if (AccessUser.currentUser != null)
            {
                Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id).OrderByDescending(x => x.CHECKED).OrderByDescending(x => x.ID));
                uncheck = DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id && x.CHECKED == "Chưa xem").ToList().Count();
                notePopUp = "Bạn có " + uncheck + " thông báo mới";
                userName = AccessUser.currentUser.userName;
                
            }

            PopUpOpened = new RelayCommand<UserControl>((p) => { return p != null ? true : false; }, 
                (p) =>
                {
                    

                });
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
                    System.Diagnostics.Process.Start("http://www.uit.edu.vn");

                });
            FeedBackClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {

                });
            CartClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    MainViewModel.addViewToStack(new CartViewModel());


                });
            VisibleCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p)=>
                {
                    if (AccessUser.currentUser == null)
                    {
                        return;
                    }
                    Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id).OrderByDescending(x => x.CHECKED).OrderByDescending(x => x.ID));
                    uncheck = DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id && x.CHECKED == "Chưa xem").ToList().Count();
                    notePopUp = "Bạn có " + uncheck + " thông báo mới";
                    userName = AccessUser.currentUser.userName;
                    

                });
            IconClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; }, 
                (p)=>
                {
                    MainViewModel.Instance.CurrentView = new CategoryViewModel();
                }
                );
            SearchCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    DashboardUC.m = 0;   
                    AccessUser.searchWd = searchWd;
                    if (!MainViewModel.Instance.CurrentView.GetType().Equals(typeof(SearchFilterProductViewModel)))
                    {
                        MainViewModel.addViewToStack(new SearchFilterProductViewModel(/*SearchWD*/));

                    }
                    else
                    {
                        //MainViewModel.Instance.CurrentView = new CategoryViewModel(/*SearchWD*/);
                        SearchFilterProduct._searchFilterProductViewModel.SearchValue = searchWd;
                        SearchFilterProduct._searchFilterProductViewModel.ProductToList();


                    }
                    //MainViewModel.Instance.CurrentView = new SearchFilterProductViewModel();


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
