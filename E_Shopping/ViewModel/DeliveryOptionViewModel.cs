using E_Shopping.Model;
using E_Shopping.UserControlBar.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class DeliveryOptionViewModel:BaseViewModel
    {
        public ICommand ContinueMakePaymentCommand { get; set; }
        public ICommand BackToShipingDetailCommand { get; set; }
        //final value

        public const double constStandardFee = 2000;//1km
        public const double constBusinessFee = 5000;//1km
        public const double constSameDayFee = 10000;//1km
         
        public double km;

        public static DELIVERY deliveryInfo { get; set; }

        public static int i = 0;
        //Attribute
        private bool _standardDelivery;
        public bool standardDelivery { get => _standardDelivery; 
            set {
                _standardDelivery = value;
                OnPropertyChanged();
            }
        }

        private bool _businessDelivery;
        public bool businessDelivery { get => _businessDelivery;
            set {
                _businessDelivery = value;
                OnPropertyChanged(); 
            }
        }

        private bool _sameDayDelivery;
        public bool sameDayDelivery { get => _sameDayDelivery; 
            set {
                _sameDayDelivery = value; OnPropertyChanged();
            }
        }


        private double _standardDeliveryPrice;
        public double standardDeliveryPrice { get => _standardDeliveryPrice; set { _standardDeliveryPrice = value; OnPropertyChanged(); } }


        private double _businessDeliveryPrice;
        public double businessDeliveryPrice { get => _businessDeliveryPrice; set { _businessDeliveryPrice = value; OnPropertyChanged(); } }

        private double _sameDayDeliveryPrice;
        public double sameDayDeliveryPrice { get => _sameDayDeliveryPrice; set { _sameDayDeliveryPrice = value; OnPropertyChanged(); } }

        public DeliveryOptionViewModel()
        {
            
            
            standardDelivery = true;
            businessDelivery = sameDayDelivery = false;

            BackToShipingDetailCommand = new RelayCommand<DeliveryOption>((p) =>
            {
                return true;
            }, (p) => {
                ShippingAddressViewModel.removeViewToStack(); 
                }
            );

            ContinueMakePaymentCommand = new RelayCommand<DeliveryOption>((p) =>
            {
                return true;
            }, (p) => {
                ShippingAddressViewModel.addViewToStack();
            }
            );
        }
        public void CalculateFee(double subtotal)
        {


            ShippingAddressViewModel.Instance.shippingFee = standardDeliveryPrice;

            standardDeliveryPrice = km * constStandardFee;

            if (subtotal >= 1000000)
            {
                businessDeliveryPrice = 0;
            }
            else
            {
                businessDeliveryPrice = km * constBusinessFee;
            }
            if (subtotal >= 5000000)
            {
                sameDayDeliveryPrice = 0;
            }
            else
            {
                sameDayDeliveryPrice = km * constSameDayFee;

            }

            //standardDeliveryPrice = km * constStandardFee;
            //sameDayDeliveryPrice = km * constSameDayFee;
            //businessDeliveryPrice = km * constBusinessFee;
        }
        public void changeShippingFee()
        {
            if (standardDelivery)
            {
                ShippingAddressViewModel.Instance.shippingFee = standardDeliveryPrice;
                deliveryInfo = new DELIVERY() { type = "standard", cost = (long)standardDeliveryPrice };
            }
            else if (businessDelivery)
            {
                ShippingAddressViewModel.Instance.shippingFee= businessDeliveryPrice;
                deliveryInfo = new DELIVERY() { type = "business", cost = (long)businessDeliveryPrice };
            }
            else
            {
                ShippingAddressViewModel.Instance.shippingFee = sameDayDeliveryPrice;
                deliveryInfo = new DELIVERY() { type = " sameDay", cost = (long)sameDayDeliveryPrice };

            }
        }
    }
}
