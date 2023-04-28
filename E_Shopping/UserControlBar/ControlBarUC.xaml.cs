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
            Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p=>p.IDPEOPLE == 2).OrderByDescending(p => p.CHECKED).OrderByDescending(p => p.ID));
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == 2 && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            lvUsers.ItemsSource = Notifies;
            notifipopup.ToolTip = $"Bạn có {uncheck} thông báo mới";

            UserNamelb.Content = DataProvider.ins.DB.PEOPLE.Find(2).userName;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);

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
                update.CHECKED = "Đã xem";
                DataProvider.ins.DB.SaveChanges();
            }
            catch (Exception)
            {

                return;
            }

        }

        private void PopOpened(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == 2 && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == 2));
            lvUsers.ItemsSource = Notifies;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void PopClosed(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDPEOPLE == 2 && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            notifipopup.ToolTip = $"Bạn có {uncheck} thông báo mới";
        }
    }
}
