using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.UserControlBar.Screen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class ShippingAddressViewModel:BaseViewModel
    {

        private ObservableCollection<ORDER> _listItem;
        public ObservableCollection<ORDER> listItem { get => _listItem; set { _listItem = value; OnPropertyChanged(); } }
        public void setListItem(ObservableCollection<ORDER> listItem)
        {
            this.listItem = listItem;
        }
        private static double _subTotal;
        public double subTotal { get  {
                return _subTotal;
          }
            set {
                totalDue = value + saleTax + shippingFee;
                _subTotal = value; 
                OnPropertyChanged(); 
            }
        }



        private double _saleTax;
        public double saleTax { get => _saleTax;
            set {
                totalDue = value + subTotal + shippingFee;

                _saleTax = value;
                OnPropertyChanged(); 
            }
        }

        private double _shippingFee;
        public  double shippingFee { get => _shippingFee;
            set {
                totalDue = value + saleTax + subTotal;
                _shippingFee = value; OnPropertyChanged();
            } 
        }
        private double _totalDue;
        public double totalDue { get
            {
                //_totalDue = subTotal + saleTax + shippingFee;
                return _totalDue;
            }  set { _totalDue = value; OnPropertyChanged(); } }


        private string _giftcode;
        public string giftcode
        {
            get => _giftcode;
            set
            {
                _giftcode = value; OnPropertyChanged();
            }
        }
        private int _idGiftCode;
        public int idGiftCode
        {
            get => _idGiftCode;
            set
            {
                _idGiftCode = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplyGiftCodeCommand { get; set; }
        public static List<object> list { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private static ShippingAddressViewModel _Instance;
        public static ShippingAddressViewModel Instance
        {
            get
            {
                if (_Instance==null)
                {
                    _Instance = new ShippingAddressViewModel();
                }

                return _Instance;

            }
            set { _Instance = value; }
        }
        public static Stack<object> stackView = new Stack<object>();
    
        public static void addViewToStack(double km=0)
        {
            //int index = list.IndexOf(Instance.CurrentView);
            int index = 0;

            if (Instance.CurrentView.GetType() == typeof(ShippingDetailsViewModel))
            {
                index = 0;
                (list[index + 1] as DeliveryOptionViewModel).km = km;
                (list[index + 1] as DeliveryOptionViewModel).CalculateFee(_subTotal);
            }
            else if (Instance.CurrentView.GetType() == typeof(DeliveryOptionViewModel))
            {
                index = 1;
            }
            else if (Instance.CurrentView.GetType() == typeof(PaymentOptionsViewModel))
            {
                index = 2;
            }
            if (index < 2)
            {
                Instance.CurrentView = list[index + 1];
                stackView.Push(list[index + 1]);
            }

        }
        public static void removeViewToStack()
        {
            stackView.Pop();
            Instance.CurrentView = stackView.Peek();
        }
       


        //Command
        public ICommand BackToCartCommand { get; set; }
    

        
        public void BackToCart()
        {
            MainViewModel.removeViewToStack();
        }
        public void BackToEmptyCart()
        {
            MainViewModel.returnToEmptyCard();
        }
        public ShippingAddressViewModel()
        {
            list = new List<object>();
            //listItem = CartViewModel.getitembuy();
            listItem = new ObservableCollection<ORDER>();
            list.Add(new ShippingDetailsViewModel());
            list.Add(new DeliveryOptionViewModel());
            list.Add(new PaymentOptionsViewModel());

            totalDue = saleTax + subTotal + shippingFee;

            
            BackToCartCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => { BackToCart(); });

            ApplyGiftCodeCommand=new RelayCommand<object> ((p) =>
            {
                return true;
            }, (p) => { ApplyGiftCode(); }
            );
            // Startup Page
            CurrentView = list[0];
            stackView.Clear();
            stackView.Push(CurrentView);
        }

       public void ApplyGiftCode()
        {
            if (giftcode=="")
            {
                saleTax = 0;
                 ValidationNotify validationNotify =new ValidationNotify("Giftcode is empty!!");
                validationNotify.ShowDialog();
                return;
            }
            DISCOUNT dis = DataProvider.ins.DB.Database.SqlQuery<DISCOUNT>("SELECT *  FROM DISCOUNT WHERE code = @giftcode ", new SqlParameter("@giftcode",giftcode)).FirstOrDefault<DISCOUNT>();
            if (dis==null)
            {
                saleTax = 0;
                ValidationNotify validationNotify = new ValidationNotify("Giftcode is not exist!!");
                validationNotify.ShowDialog();
                return;
            }
            else
            {
                //Mốt đổi idCus thành id User
                int idCus = 2;
                if (dis.idCustomer != idCus)
                {
                    ValidationNotify validationNotify = new ValidationNotify("Giftcode is not belong to user!!");
                    validationNotify.ShowDialog();
                    return;
                }
                else
                {
                    if (dis.status=="Used")
                    {
                        giftcode = "";
                        ValidationNotify validationNotify = new ValidationNotify("Giftcode is used!!");
                        validationNotify.ShowDialog();
                        return;
                    }
                    if (dis.exp_time < DateTime.Today)
                    {
                        giftcode = "";
                        ValidationNotify validationNotify = new ValidationNotify("Giftcode is expired!!");
                        validationNotify.ShowDialog();
                        return;
                    }
                }
            }
            Instance.idGiftCode = dis.id;
            Instance.saleTax = (-1)*((double) (totalDue * dis.value) / 100);
        }
    }
}
