using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public bool IsLoad = false;

        public ICommand LoadedWindowCommand { get; set; }


        private static ObservableCollection<CHATBOX> _chatBox;
        public ObservableCollection<CHATBOX> chatBox { get => _chatBox; set { _chatBox = value; OnPropertyChanged(); } }

        private object _currentView;
        public  object CurrentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        
        private static MainViewModel _Instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MainViewModel();
                }
                return _Instance;

            }
            set { _Instance = value; }
        }
        public static Stack<object> stackView = new Stack<object>();

        public static void addViewToStack(object view)
        {
           Instance.CurrentView = view;
           stackView.Push(view);   
        }
        public static void removeViewToStack()
        {
            if (stackView.Count!=0)
            {
                stackView.Pop();
                if (stackView.Peek().GetType().Equals(typeof(CartViewModel)))
                {
                    stackView.Pop();
                    stackView.Push(new CartViewModel() { subTotal=0});
                }
                Instance.CurrentView = stackView.Peek();
            }
           
        }

        public static void returnToEmptyCard()
        {
            if (stackView.Count!=0)
            {
                stackView.Pop();
                if (stackView.Count != 0)
                {
                    CartViewModel cartViewModel = stackView.Pop() as CartViewModel;
                    cartViewModel.deleteItemIsBought();

                    CartViewModel temps = new CartViewModel() { subTotal = 0 };

                    //Mốt chỉnh bên cartViewModel
                    temps.shoppingCarts = cartViewModel.shoppingCarts;
                    stackView.Push(temps);
                    Instance.CurrentView = stackView.Peek();
                    //Instance.CurrentView = new CartViewModel();

                }
            
            }
          
        }


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

                    AccessUser.currentUser = DataProvider.ins.db.PEOPLE.Where(k => k.userName == loginVM.UserName).FirstOrDefault();
                    // Startup Page
                    if (AccessUser.currentUser.idRole == 1)
                    {
                        chatBox = new ObservableCollection<CHATBOX>(DataProvider.ins.DB.CHATBOXes.Where(m => m.idCustomer == AccessUser.currentUser.id));

                    }
                    Instance.CurrentView = new CategoryViewModel();
                    stackView.Push(CurrentView);
                    (p as MainWindow).ControlBar.DataContext = new ControlBarViewModel();
                    p.Show();

                }
                else
                {
                    p.Close();
                }
            });



            
            // CurrentView = new OrderedHistoryViewModel();


            //Mốt chuyển thành idUser
            int userID = 2;

           
        }
            
    }
}
