using E_Shopping.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using E_Shopping.Model;
using System.Collections.ObjectModel;
using System.IO;
using E_Shopping.Class;

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarViewModel viewModel { get; set; }
        public ObservableCollection<Notification> Notifies { get; set; }

        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = viewModel = new ControlBarViewModel();
            if(AccessUser.currentUser != null)
            {
                switch (AccessUser.currentUser.idRole)
                {
                    case 1:
                        {

                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            }

            //Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p=>p.IDPEOPLE == AccessUser.currentUser.id).OrderByDescending(p => p.CHECKED).OrderByDescending(p => p.ID));
            //int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == AccessUser.currentUser.id && p.CHECKED == "Chưa xem").ToList().Count();
            //numberofnotifies.Badge = uncheck;
            //lvUsers.ItemsSource = Notifies;
            //notifipopup.ToolTip = $"Bạn có {uncheck} thông báo mới";

            //UserNamelb.Content = DataProvider.ins.DB.PEOPLE.Find(AccessUser.currentUser.id).userName;
            if (lvUsers.ItemsSource == null)
            {
                return;
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);

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
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void FeedBack_Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            Feedback feed = new Feedback();
            feed.Show();
        }

        private void Chat_Click(object sender, MouseButtonEventArgs e)
        {

        }
        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            Notification notification = listView.SelectedItem as Notification;
            Notification update = DataProvider.ins.DB.Notifications.Find(notification.ID);
            try
            {
                update.CHECKED = "Seen";
                DataProvider.ins.DB.SaveChanges();
            }
            catch (Exception)
            {

                return;
            }

        }

        private void PopOpened(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == AccessUser.currentUser.id && p.CHECKED == "Unseen").ToList().Count();
            numberofnotifies.Badge = uncheck;
            Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == AccessUser.currentUser.id));
            lvUsers.ItemsSource = Notifies;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void PopClosed(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == AccessUser.currentUser.id && p.CHECKED == "Unseen").ToList().Count();
            numberofnotifies.Badge = uncheck;
            if(uncheck == 1)
                notifipopup.ToolTip = $"You have {uncheck} new notification";
            else
                notifipopup.ToolTip = $"You have {uncheck} new notifications";

        }

        private void Accountcbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            int index = combo.SelectedIndex;
            ComboBoxItem select = (ComboBoxItem)combo.SelectedItem;
            if(select != null)
            {
                switch(index)
                {
                    case 0:
                        {
                            MainViewModel.Instance.CurrentView = new UserInfoViewModel();

                            break;
                        }
                    case 1:
                        {
                            MainViewModel.Instance.CurrentView = new OrderedHistoryViewModel();
                            break;
                        }
                    case 2:
                        {
                            MainViewModel.Instance.CurrentView = new ConfirmOrderViewModel();
                            break;
                        }
                    case 3:
                        {
                            ChatBoxScreen chatBoxScreen = new ChatBoxScreen();
                            chatBoxScreen.ShowDialog();
                            break;
                        }
                    
                    case 4:
                        {
                            AccountInfo accountInfo = new AccountInfo();
                            accountInfo.ShowDialog();
                            break;
                        }
                    case 5:
                        {
                            MainViewModel.Instance.CurrentView = new UserManageViewModel();
                            break;
                        }
                    case 6:
                        {
                            MainViewModel.Instance.CurrentView = new ManageProductForOwnerViewModel();
                            break;
                        }
                    case 7:
                        {
                            MainViewModel.Instance.CurrentView = new ChartViewModel();
                            break;
                        }
                    case 8:
                        {
                            Window window = Application.Current.MainWindow as Window;

                            if (window != null)
                            {
                                MainWindow mainWindow = new MainWindow();
                                window.Close();
                                Application.Current.MainWindow = mainWindow;
                                Application.Current.MainWindow.Show();
                            }
                            break;
                        }
                       

                }
                combo.SelectedItem = null;

            }
            combo.SelectedIndex = -1;
        }

        private void Accountcbb_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (AccessUser.currentUser != null)
            {
                switch (AccessUser.currentUser.idRole)
                {
                    case 1:
                        {
                            ComboBoxItem item = (ComboBoxItem)Accountcbb.Items[3];
                            ComboBoxItem item1 = (ComboBoxItem)Accountcbb.Items[5];
                            ComboBoxItem item2 = (ComboBoxItem)Accountcbb.Items[6];
                            ComboBoxItem item3 = (ComboBoxItem)Accountcbb.Items[7];

                            item.Visibility = item1.Visibility = item2.Visibility = item3.Visibility = Visibility.Collapsed;
                            
                            break;
                        }
                    case 2:
                        {
                            ComboBoxItem item1 = (ComboBoxItem)Accountcbb.Items[5];
                            ComboBoxItem item2 = (ComboBoxItem)Accountcbb.Items[6];
                            ComboBoxItem item3 = (ComboBoxItem)Accountcbb.Items[7];

                            item1.Visibility = item2.Visibility = item3.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 3:
                        {
                            ComboBoxItem item = (ComboBoxItem)Accountcbb.Items[3];
                            item.Visibility = Visibility.Collapsed;
                            break;
                        }
                }
            }
        }
    }
}
