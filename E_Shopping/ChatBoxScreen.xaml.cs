using E_Shopping.Model;
using E_Shopping.ViewModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace E_Shopping
{
    /// <summary>
    /// Interaction logic for ChatBoxScreen.xaml
    /// </summary>
    public partial class ChatBoxScreen : Window
    {
        List<CHATBOX> data1;
        List<CHATBOX> data2;
        int flag = 0;
        CHATBOX chatBox1;
        public ChatBoxScreen()
        {
            InitializeComponent();
            //Timer for chatbox
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CHATBOX chatBox = chatBox1;

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
                    var c = DataProvider.ins.DB.Database.SqlQuery<CHATBOX>("  Select B.id, A.idCustomer,B.idAssistant, B.content, B.isSend From (Select idCustomer From CHATBOX Group By idCustomer) As A Join CHATBOX B On A.idCustomer= B.idCustomer where B.id In ( Select Top 1 (Id)  From CHATBOX where idCustomer=B.idCustomer Order By id Desc)");
                    (this.DataContext as ChatBoxScreenViewModel).listUserChat = new ObservableCollection<CHATBOX>(c);
                    (this.DataContext as ChatBoxScreenViewModel).Chat = new ObservableCollection<CHATBOX>(list.Where(m => m.idAssistant == 3 && m.idCustomer == chatBox.idCustomer));
                }
            }
            data2 = data1;

            try
            {
                userChatList.SelectedItem = userChatList.Items[getIndexOfUserChatSelected(chatBox1)];

            }
            catch (Exception)
            {
                return;
            }
        }
        public int getIndexOfUserChatSelected(CHATBOX chat)
        {
            for (int i = 0; i < userChatList.Items.Count; i++)
            {
                if ((userChatList.Items[i] as CHATBOX).idCustomer == chat.idCustomer)
                {
                    return i;
                }
            }
            return -1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void MessageList_Loaded(object sender, RoutedEventArgs e)
        {
            if (MessageList != null && MessageList.Items.Count != 0)
            {
                MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);

            }
        }

       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CHATBOX chatBox = userChatList.SelectedItem as CHATBOX;
                if (chatBox!=null)
                {
                    chatBox1 = chatBox;

                }

                (this.DataContext as ChatBoxScreenViewModel).Chat = new ObservableCollection<CHATBOX>(DataProvider.ins.DB.CHATBOXes.Where(m => m.idAssistant == 3 && m.idCustomer == chatBox.idCustomer));
                (this.DataContext as ChatBoxScreenViewModel).person = DataProvider.ins.DB.PEOPLE.Find(chatBox.idCustomer);
                MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
            }
            catch (Exception)
            {

                return;
            }
          
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = Message.Text.ToString();
            if (text == null || text == "")
            {
                return;
            }
            CHATBOX chatBox = userChatList.SelectedItem as CHATBOX;
            (this.DataContext as ChatBoxScreenViewModel).Chat.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = chatBox.idCustomer, content = text, isSend = 1 });
            DataProvider.ins.DB.CHATBOXes.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = chatBox.idCustomer, content = text, isSend = 1 });
            DataProvider.ins.DB.SaveChanges();
            Message.Text = "";
            MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
        }

        private void userChatList_Loaded(object sender, RoutedEventArgs e)
        {
            if (userChatList!=null&&userChatList.Items.Count!=0)
            {
                userChatList.SelectedItem = userChatList.Items[0];

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CHATBOX> userChats = (this.DataContext as ChatBoxScreenViewModel).listUserChat.ToList();
            var tbx = (TextBox)sender;
            if (tbx.Text != "")
            {
                var filterList = userChats.Where(x => x.Customer.userName.ToLower().Contains(tbx.Text.ToLower()));
                userChatList.ItemsSource = null;
                userChatList.ItemsSource = filterList;
            }
            else
            {
                userChatList.ItemsSource = userChats;
            }
        }
    }
}
