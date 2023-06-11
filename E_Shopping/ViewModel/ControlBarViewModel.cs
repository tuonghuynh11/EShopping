using E_Shopping.Class;
using E_Shopping.Model;
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
using System.Windows.Threading;

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
            set { userName = value; OnPropertyChanged(); }
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
            set { avatar = value; OnPropertyChanged("Avatar"); }
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
        List<Notification> currentNotifies;
        List<Notification> changedNotifies;
        int flag = 0;
        public static string changedAvatar;
        DispatcherTimer timer_Avatar;
        DispatcherTimer timer_Notification;
        public ControlBarViewModel()
        {
            if (AccessUser.currentUser != null)
            {
                Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id).OrderByDescending(x => x.CHECKED).OrderByDescending(x => x.ID));
                uncheck = DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id && x.CHECKED == "Unseen").ToList().Count();
                if (uncheck == 1)
                    notePopUp = $"You have {uncheck} new notification";
                else
                    notePopUp = $"You have {uncheck} new notifications";
                userName = AccessUser.currentUser.userName.Length > 7 ? AccessUser.currentUser.userName.Substring(0, 5) + ".." : AccessUser.currentUser.userName;
                Avatar = AccessUser.currentUser.avatar;
                timer_Avatar = new DispatcherTimer();
                timer_Avatar.Interval = TimeSpan.FromSeconds(3);
                timer_Avatar.Tick += new EventHandler(timer_Tick_avatartimer);
                timer_Avatar.Start();
                timer_Notification = new DispatcherTimer();
                timer_Notification.Interval = TimeSpan.FromSeconds(3);
                timer_Notification.Tick += new EventHandler(timer_Tick_notifies);
                timer_Notification.Start();

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
                        System.Windows.Application.Current.Shutdown();
                        timer_Avatar.Stop();
                        timer_Notification.Stop();

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
                    //ChatBoxScreen chatBoxScreen = new ChatBoxScreen();
                    //chatBoxScreen.ShowDialog();

                    //ObservableCollection<ORDER> buyingList = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(e => (e.status == 1 || e.status == 2) && e.idCart == AccessUser.currentUser.idCart));
                    //buyingList[0].status = 3;
                    //DataProvider.ins.DB.SaveChanges();
                    Feedback feedBack = new Feedback();
                    feedBack.ShowDialog();
                });
            CartClick = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    MainViewModel.addViewToStack(new CartViewModel());


                });
            VisibleCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
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
                (p) =>
                {
                    MainViewModel.Instance.CurrentView = new CategoryViewModel();
                }
                );
            SearchCommand = new RelayCommand<UserControl>((p) => { return p != null ? true : false; },
                (p) =>
                {
                    if (searchWd != null)
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
                    }



                });


        }
        void timer_Tick_avatartimer(object sender, EventArgs e)
        {

            if (changedAvatar != null && changedAvatar.Length != 0)
            {
                if (changedAvatar != Avatar)
                {
                    Avatar = changedAvatar;

                }
            }


        }
        void timer_Tick_notifies(object sender, EventArgs e)
        {
            changedNotifies = DataProvider.ins.db.Notifications.ToList();
            if (flag == 0)
            {
                flag = 1;
            }
            else
            {
                if (currentNotifies.Count != changedNotifies.Count)
                {
                    Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id).OrderByDescending(x => x.CHECKED).OrderByDescending(x => x.ID));
                    Uncheck = DataProvider.ins.DB.Notifications.Where(x => x.IDPEOPLE == AccessUser.currentUser.id && x.CHECKED == "Unseen").ToList().Count();

                    if (uncheck == 1)
                        NotifyPopUp = $"You have {uncheck} new notification";
                    else
                        NotifyPopUp = $"You have {uncheck} new notifications";

                }
            }
            currentNotifies = changedNotifies;


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
