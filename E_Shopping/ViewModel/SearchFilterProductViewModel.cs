using E_Shopping.Model;
using E_Shopping.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Globalization;
using System.Security.Cryptography.Xml;

namespace E_Shopping.ViewModel
{
    public class SearchFilterProductViewModel : BaseViewModel
    {
        private ObservableCollection<PRODUCT> _listProductsOG;
        private ObservableCollection<PRODUCT> _listProducts;
        public ObservableCollection<PRODUCT> ListProductsOG
        {
            get { return _listProductsOG; }
            set
            {
                _listProductsOG = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PRODUCT> ListProducts
        {
            get { return _listProducts; }
            set { _listProducts = value; OnPropertyChanged(); }
        }
        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set {
                _searchValue = value;
                OnPropertyChanged();
            }
        }
        private string _imageProduct;
        public string ImageProduct
        {
            get => _imageProduct;
            set
            {
                _imageProduct = value;
                OnPropertyChanged();
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private long _price;
        public long Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        } 
        /*
        private string _priceString;
        public string PriceString
        {
            get
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                return price.ToString("#,###", cul.NumberFormat);
            }
            set
            {
                _priceString = value;
                OnPropertyChanged();
            }
        }
        */
        private int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }
        private string _ratingStar; 
        public string RatingStar
        {
            get {
                double averageProductRating = 4.5;
                int rating = (int)averageProductRating;
                string rateImageSource = "/Assets/Images/Star_rating_0_of_5.png";
                switch (rating)
                {
                    case 0:
                        rateImageSource = "/Assets/Images/Star_rating_0_of_5.png";
                        break;
                    case 1:
                        rateImageSource = "/Assets/Images/Star_rating_1_of_5.png";
                        break;
                    case 2:
                        rateImageSource = "/Assets/Images/Star_rating_2_of_5.png";
                        break;
                    case 3:
                        rateImageSource = "/Assets/Images/Star_rating_3_of_5.png";
                        break;
                    case 4:
                        rateImageSource = "/Assets/Images/Star_rating_4_of_5.png";
                        break;
                    case 5:
                        rateImageSource = "/Assets/Images/Star_rating_5_of_5.png";
                        break;
                }
                return rateImageSource;
            }
            set
            {
                _ratingStar = value;
                OnPropertyChanged();
            }
        }
        private PRODUCT _selectedProduct;
        public PRODUCT SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }
        private int[] _checkRatingStar = new int[5];
        public int[] CheckRatingStar
        {
            get => _checkRatingStar;
            set
            {
                _checkRatingStar = value;
                OnPropertyChanged();
            }
        }
        private void ProductToList()
        {
            /*
            ListProductsOG = new ObservableCollection<PRODUCT>(DataProvider.Ins.DB.PRODUCTs);
            ListProducts = new ObservableCollection<PRODUCT>();
            foreach (PRODUCT product in DataProvider.Ins.DB.PRODUCTs)
            {
                CATEGORY category = product.CATEGORY;
                string productName = product.name;
                if (category.type.Contains(SearchValue) || productName.Contains(SearchValue))
                {
                    ListProducts.Add(product);
                }
            }
            */
            ListProductsOG = new ObservableCollection<PRODUCT>(DataProvider.Ins.DB.PRODUCTs);
            ListProducts = ListProductsOG;
            for (int i = 0; i < 5; i++)
            {
                CheckRatingStar[i] = 0;
            }
        }
        private string _minPrice;
        public string MinPrice
        {
            get => _minPrice;
            set
            {
                _minPrice = value;
                OnPropertyChanged();
            }
        }
        public string _maxPrice;
        public string MaxPrice
        {
            get => _maxPrice;
            set
            {
                _maxPrice = value;
                OnPropertyChanged();
            }
        }
        private bool _filterChanged;
        public bool FilterChanged
        {
            get => _filterChanged;
            set
            {
                _filterChanged = value;
                OnPropertyChanged();
            }
        }
        private int _filterPrice;
        public int FilterPrice
        {
            get => _filterPrice;
            set
            {
                _filterPrice = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplyCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand TopSalesCommand { get; set; }
        public ICommand LatestCommand { get; set; }
        public ICommand LowToHighCommand { get; set; }
        public ICommand HighToLowCommand { get; set; }
        public ICommand Rating5Star { get; set; }
        public ICommand Rating4Star { get; set; }
        public ICommand Rating3Star { get; set; }
        public ICommand Rating2Star { get; set; }
        public ICommand Rating1Star { get; set; }
        //public SearchFilterProductViewModel() { }
        public int checkIndexRatingStar()
        {
            for (int i = 0; i < 5; i++)
            {
                if (CheckRatingStar[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        public SearchFilterProductViewModel(/*string searchValue*/)
        {
            //SearchValue = searchValue;
            Rating5Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 4)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[4] == 1)
                {
                    CheckRatingStar[4] = 0;
                }
                else
                {
                    CheckRatingStar[4] = 1;
                }
            });
            Rating4Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 3)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[3] == 1)
                {
                    CheckRatingStar[3] = 0;
                }
                else
                {
                    CheckRatingStar[3] = 1;
                }

            });
            Rating3Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 2)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[2] == 1)
                {
                    CheckRatingStar[2] = 0;
                }
                else
                {
                    CheckRatingStar[2] = 1;
                }

            });
            Rating2Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[1] == 1)
                {
                    CheckRatingStar[1] = 0;
                }
                else
                {
                    CheckRatingStar[1] = 1;
                }

            });
            Rating1Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[0] == 1)
                {
                    CheckRatingStar[0] = 0;
                }
                else
                {
                    CheckRatingStar[0] = 1;
                }

            });
            FilterPrice = 0;
            ProductToList();
            ApplyCommand = new RelayCommand<object>((p) =>
            {
                if (MinPrice == null || MaxPrice == null)
                {
                    return false;
                }
                long minPrice = Int64.Parse(MinPrice);
                long maxPrice = Int64.Parse(MaxPrice);
                if (minPrice > maxPrice)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                FilterChanged = true;
                ListProducts = new ObservableCollection<PRODUCT>();
                long minPrice = Int64.Parse(MinPrice);
                long maxPrice = Int64.Parse(MaxPrice);
                foreach (PRODUCT product in ListProductsOG)
                {
                    if (product.price >= minPrice && product.price <= maxPrice)
                    {
                        ListProducts.Add(product);
                    }
                }
            });
            ClearCommand = new RelayCommand<object>((p) =>
            {
                return FilterChanged;
            }, (p) =>
            {
                FilterChanged = false;
                ListProducts = ListProductsOG;
            });
            TopSalesCommand = new RelayCommand<object>((p) =>
            {
                return false;
            }, (p) =>
            {

            });
            LatestCommand = new RelayCommand<object>((p) =>
            {
                return false;
            }, (p) =>
            {

            });
            LowToHighCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (FilterPrice == -1)
                {
                    FilterPrice = 0;
                    ListProducts = ListProductsOG;
                }
                else
                {
                    FilterPrice = -1;
                    ListProducts = new ObservableCollection<PRODUCT>(ListProductsOG.OrderBy(o => o.price));
                }
                OnPropertyChanged();
            });
            HighToLowCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (FilterPrice == 1)
                {
                    FilterPrice = 0;
                    ListProducts = ListProductsOG;
                }
                else
                {
                    FilterPrice = 1;
                    ListProducts = new ObservableCollection<PRODUCT>(ListProductsOG.OrderByDescending(o => o.price));
                }
                OnPropertyChanged();
            });
        }
    }
}