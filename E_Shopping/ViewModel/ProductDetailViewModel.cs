using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class ProductDetailViewModel : BaseViewModel
    {
        
        #region comands
        public ICommand BuyItNowCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DecreaseQuantityCommand { get; set; }
        #endregion
        public ProductDetailViewModel() {
            QuantityProduct = 0;
            QuantityTextBox = "1";
            IncreaseQuantityCommand = new RelayCommand<object>((p) =>
            {
                if (Int32.Parse(QuantityTextBox) >= QuantityProduct)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                int quantity = Int32.Parse(QuantityTextBox) + 1;
                QuantityTextBox = quantity.ToString();
            });
            DecreaseQuantityCommand = new RelayCommand<object>((p) =>
            {
                if (Int32.Parse(QuantityTextBox) <= 1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                int quantity = Int32.Parse(QuantityTextBox) - 1;
                QuantityTextBox = quantity.ToString();
            });
            BuyItNowCommand = new RelayCommand<object>((p) =>
            {
                if (QuantityProduct < 1)
                {
                    return false; 
                }
                return true;
            }, (p) =>
            {

            });
            AddToCartCommand = new RelayCommand<object>((p) =>
            {
                if (QuantityProduct < 1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {

            });
        }
        public ProductDetailViewModel(int _idProduct)
        {
            idProduct = _idProduct;
        }
        private int idProduct;
        public int IdProduct { 
            get => idProduct;
            set
            {
                idProduct = value;
                OnPropertyChanged();
            }
        }
        private int _quantityProduct;
        public int QuantityProduct
        {
            get => _quantityProduct;
            set
            {
                _quantityProduct = value;
                OnPropertyChanged();
            }
        }
        private string _quantityTextBox;
        public string QuantityTextBox
        {
            get => _quantityTextBox;
            set
            {
                _quantityTextBox = value;
                OnPropertyChanged();
            }
        }
    }
}
