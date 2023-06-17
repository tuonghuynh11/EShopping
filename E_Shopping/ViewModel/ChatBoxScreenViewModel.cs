using E_Shopping.Class;
using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.ViewModel
{
    public class ChatBoxScreenViewModel:BaseViewModel
    {
        private  ObservableCollection<CHATBOX> _listUserChat;
        public ObservableCollection<CHATBOX> listUserChat { get => _listUserChat; set { _listUserChat = value; OnPropertyChanged(); } }

        private  ObservableCollection<CHATBOX> _Chat;
        public ObservableCollection<CHATBOX> Chat { get => _Chat; set { _Chat = value; OnPropertyChanged(); } }
        private  Person _person;
        public Person person { get => _person; set { _person = value; OnPropertyChanged(); } }

        public ChatBoxScreenViewModel()
        {
            //var c = DataProvider.ins.DB.Database.SqlQuery<CHATBOX>(
            //    " Select B.id, A.idCustomer,B.idAssistant, B.content, B.isSend " +
            //    "From "+
            //    "(Select idCustomer" +
            //    "From CHATBOX " +
            //    "Group By idCustomer) As A " +
            //    "Join CHATBOX B " +
            //    "On A.idCustomer = B.idCustomer " +
            //     "where B.id In "+
            //      "( "+
            //       "Select Top 1(Id) "+
            //        "From CHATBOX "+
            //         "where idCustomer = B.idCustomer "+
            //         "Order By id Desc)"
            //    );
            var c = DataProvider.ins.DB.Database.SqlQuery<CHATBOX>("  Select B.id, A.idCustomer,B.idAssistant, B.content, B.isSend From (Select idCustomer From CHATBOX Group By idCustomer) As A Join CHATBOX B On A.idCustomer= B.idCustomer where B.id In ( Select Top 1 (Id)  From CHATBOX where idCustomer=B.idCustomer Order By id Desc)");

            listUserChat = new ObservableCollection<CHATBOX>(c);

             if (listUserChat.Count!=0)
            {
                CHATBOX person0 = listUserChat.ElementAt(0);
                Chat = new ObservableCollection<CHATBOX>(DataProvider.ins.DB.CHATBOXes.Where(m => m.idAssistant == 3 && m.idCustomer == person0.idCustomer));
                person = DataProvider.ins.DB.PEOPLE.Find(person0.idCustomer);
            }
        }
    }
}
