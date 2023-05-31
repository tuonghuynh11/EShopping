using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shopping.Model;

namespace E_Shopping.ViewModel
{
    internal class MainScreenViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private static MainScreenViewModel _Instance;
        public static MainScreenViewModel Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MainScreenViewModel();
                }
                return _Instance;

            }
            set { _Instance = value; }
        }
        private static ObservableCollection<CHATBOX> _chatBox;
        public ObservableCollection<CHATBOX> chatBox { get => _chatBox; set { _chatBox = value; OnPropertyChanged(); } }
        public static Stack<object> stackView = new Stack<object>();

        public static void addViewToStack(object view)
        {
            Instance.CurrentView = view;
            stackView.Push(view);
        }
        public static void removeViewToStack()
        {
            if (stackView.Count != 0)
            {
                stackView.Pop();
                if (stackView.Peek().GetType().Equals(typeof(CartViewModel)))
                {
                    stackView.Pop();
                    stackView.Push(new CartViewModel() { subTotal = 0 });
                }
                Instance.CurrentView = stackView.Peek();
            }

        }

        public static void returnToEmptyCard()
        {
            if (stackView.Count != 0)
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
        public MainScreenViewModel()
        {
            Instance.CurrentView = new CategoryViewModel();
        }
    }
}
