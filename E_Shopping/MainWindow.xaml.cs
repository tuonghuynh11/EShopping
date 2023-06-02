using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.ViewModel;
using E_Shopping.UserControlBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace E_Shopping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //So sánh sự thay đổi của database
        List<CHATBOX> data1;
        List<CHATBOX> data2;
        int flag = 0;
        int newnotifies = 0;

        DispatcherTimer timer;
        public MainWindow()
        {
        
            InitializeComponent();

            //Timer for chatbox
             timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += Timer_Tick;
           
            timer.Start();

            

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (AccessUser.currentUser!=null)
            {
                if (AccessUser.currentUser.idRole == 2 || AccessUser.currentUser.idRole == 3)
                {
                    timer.Stop();
                }
            }
           
                data1 = DataProvider.ins.db.CHATBOXes.ToList();
            if (flag == 0)
            {
                flag = 1;
                data2 = data1;
                return;
            }
            else
            {
                if (data1.Count() != data2.Count())
                {
                    List<CHATBOX> list = new List<CHATBOX>();
                    list.AddRange(data2);
                    for (int i = data2.Count(); i < data1.Count(); i++)
                    {
                        list.Add(data1[i]);
                    }
                    ObservableCollection<CHATBOX> chatBoxes;
                    if (AccessUser.currentUser.idRole == 2)
                    {
                       chatBoxes=new ObservableCollection<CHATBOX>(list.Where(p => p.idAssistant == AccessUser.currentUser.id));

                    }
                    else
                    {
                        chatBoxes = new ObservableCollection<CHATBOX>(list.Where(p => p.idCustomer == AccessUser.currentUser.id));



                    }
                    MessageList.ItemsSource = chatBoxes;

                }
            }
            data2 = data1;

        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            //Mốt chuyển thành idUser
            Person currentUser = AccessUser.currentUser;

            //Mốt check xem currentUser là customer hay assistant
            string text = messageTb.Text.ToString();
            if (text==null||text=="")
            {
                return;
            }
            if (currentUser.idRole==2)
            {
                (this.DataContext as MainViewModel).chatBox.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer =2, content = text, isSend = 1 });
                DataProvider.ins.DB.CHATBOXes.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = 2, content = text, isSend =1 });

            }
            else
            {
                (this.DataContext as MainViewModel).chatBox.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = currentUser.id, content = text, isSend = currentUser.idRole == 1 ? 0 : 1 });
                DataProvider.ins.DB.CHATBOXes.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = currentUser.id, content = text, isSend = currentUser.idRole == 1 ? 0 : 1 });

            }
            DataProvider.ins.DB.SaveChanges();
            messageTb.Text = "";
            MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
        }

        private void Flipper_Loaded(object sender, RoutedEventArgs e)
        {
            if (MessageList!=null&&MessageList.Items.Count!=0)
            {
                MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageList != null && MessageList.Items.Count != 0)
            {
                MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            chatFlipper.Visibility = Visibility.Collapsed;
            chatBtn.Visibility = Visibility.Visible;
        }

        private void chatBtn_Click(object sender, RoutedEventArgs e)
        {
            chatFlipper.Visibility = Visibility.Visible;
            chatBtn.Visibility = Visibility.Collapsed;

        }


        //private void controlBar_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    ControlBarUC obj = sender as ControlBarUC;
        //    ControlBarViewModel vm = obj.DataContext as ControlBarViewModel;
        //    if ((bool)e.NewValue)
        //    {
        //        vm.VisibleCommand.Execute(obj as UserControl);
        //    }
        //}
    }
}

        