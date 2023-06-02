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
using Stripe;
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using E_Shopping.Class;
using E_Shopping.UserControlBar;

namespace E_Shopping.ViewModel
{
    public class SearchFilterProductViewModel : BaseViewModel
    {
        private ObservableCollection<PRODUCT> _listProductsOG;
        private ObservableCollection<PRODUCT> _listProductsFiltered;
        private ObservableCollection<PRODUCTWRAPPER> _listProductsFilteredWrapper;
        private ObservableCollection<PRODUCTWRAPPER> _listProductsWrapper;
        private int _numCheckRating;
        public static Stack<object> stackView = new Stack<object>();
        private static MainViewModel _Instance;
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public static void addViewToStack(object view)
        {
            Instance.CurrentView = view;
            stackView.Push(view);
        }
        public static void removeViewToStack()
        {
            stackView.Pop();
            Instance.CurrentView = stackView.Peek();
        }
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

        public int NumCheckRating
        {
            get => _numCheckRating;
            set
            {
                _numCheckRating = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PRODUCTWRAPPER> ListProductsFilteredWrapper
        {
            get => _listProductsFilteredWrapper;
            set
            {
                _listProductsFilteredWrapper = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PRODUCTWRAPPER> ListProductsWrapper
        {
            get => _listProductsWrapper;
            set
            {
                _listProductsWrapper = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PRODUCT> ListProductsFiltered
        {
            get => _listProductsFiltered;
            set
            {
                _listProductsFiltered = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PRODUCT> ListProductsOG
        {
            get { return _listProductsOG; }
            set
            {
                _listProductsOG = value;
                OnPropertyChanged();
            }
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
        private string _id;
        private string Id
        {
            get => _id;
            set
            {
                Id = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                Name = value;
                OnPropertyChanged();
            }
        }
        private long _price;
        public long Price
        {
            get => _price;
            set
            {
                Price = value;
                OnPropertyChanged();
            }
        }

        private PRODUCTWRAPPER _selectedProduct;
        public PRODUCTWRAPPER SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;

                OnPropertyChanged();
            }
        }
        private int[] _checkRatingStar = new int[6];
        public int[] CheckRatingStar
        {
            get => _checkRatingStar;
            set
            {
                _checkRatingStar = value;
                OnPropertyChanged();
            }
        }
        private string RatingImage(PRODUCT product)
        {
            int ratingTemp = 0, count = 0;
            ObservableCollection<PRODUCTRATE> listProductRate = new ObservableCollection<PRODUCTRATE>(DataProvider.Ins.DB.PRODUCTRATEs);
            foreach (PRODUCTRATE prodRate in listProductRate)
            {
                if (prodRate.idProduct.Equals(product.id))
                {
                    ratingTemp += (int)prodRate.rate;
                    count += 1;
                }
            }
            if (count == 0)
            {
                ratingTemp = 0;
            }
            else
            {
                ratingTemp /= count;
            }

            string ratingURL = "/Assets/Images/Star_rating_0_of_5.png";
            switch (ratingTemp)
            {
                case 0:
                    ratingURL = "/Assets/Images/Star_rating_0_of_5.png";
                    break;
                case 1:
                    ratingURL = "/Assets/Images/Star_rating_1_of_5.png";
                    break;
                case 2:
                    ratingURL = "/Assets/Images/Star_rating_2_of_5.png";
                    break;
                case 3:
                    ratingURL = "/Assets/Images/Star_rating_3_of_5.png";
                    break;
                case 4:
                    ratingURL = "/Assets/Images/Star_rating_4_of_5.png";
                    break;
                case 5:
                    ratingURL = "/Assets/Images/Star_rating_5_of_5.png";
                    break;
                default:
                    ratingURL = "/Assets/Images/Star_rating_0_of_5.png";
                    break;
            }
            return ratingURL;
        }
        public void ProductToList()
        {
            string search = SearchValue.ToLower();
            ListProductsOG = new ObservableCollection<PRODUCT>(DataProvider.Ins.DB.PRODUCTs);
            ObservableCollection<ORDER> orders = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERS.Where(o => o.status == 3));
            ListProductsFiltered = new ObservableCollection<PRODUCT>();
            foreach (PRODUCT product in ListProductsOG)
            {
                CATEGORY category = product.CATEGORY;
                string productName = product.name;
                if(DashboardUC.m == 1)
                {
                    if (category.type.ToLower().Contains(search))
                    {
                        ListProductsFiltered.Add(product);
                    }
                }  
                else
                if (category.type.ToLower().Contains(search) || productName.ToLower().Contains(search))
                {
                    ListProductsFiltered.Add(product);
                }
            }
            ListProductsFilteredWrapper = new ObservableCollection<PRODUCTWRAPPER>();
            foreach (PRODUCT product in ListProductsFiltered)
            {
                int count = 0;
                foreach (ORDER order in orders)
                {
                    if (order.idProduct.Equals(product.id))
                    {
                        count++;
                    }
                }
                PRODUCTWRAPPER productWrapper = new PRODUCTWRAPPER()
                {
                    Product = product,
                    MainImage = new BitmapImage(new Uri(product.thumbnailimage)),
                    CustomPrice = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VND", product.price),
                    RatingStarImage = RatingImage(product),
                    Sold = count,
                };
                ListProductsFilteredWrapper.Add(productWrapper);
            }
            ListProductsWrapper = ListProductsFilteredWrapper;
            for (int i = 0; i < 6; i++)
            {
                CheckRatingStar[i] = 0;
            }
            OnPropertyChanged();
        }

        private string _minPrice;
        public string MinPrice
        {
            get => _minPrice;
            set
            {
                if (!string.Equals(_minPrice, value))
                {
                    _minPrice = value;
                }
                OnPropertyChanged();
            }
        }
        public string _maxPrice;
        public string MaxPrice
        {
            get => _maxPrice;
            set
            {
                if (!string.Equals(_maxPrice, value))
                {
                    _maxPrice = value;
                }
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
        public ICommand Rating0Star { get; set; }
        public ICommand BackCommand { get; set; }
        public void Back()
        {
            MainViewModel.Instance.CurrentView = new CategoryViewModel();
            stackView.Push(CurrentView);
        }

        //public SearchFilterProductViewModel() { }
        public int checkIndexRatingStar()
        {
            for (int i = 0; i < 6; i++)
            {
                if (CheckRatingStar[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        private long _minPriceNum;
        public long MinPriceNum
        {
            get => _minPriceNum;
            set
            {
                _minPriceNum = value;
                OnPropertyChanged();
            }
        }
        private long _maxPriceNum;
        public long MaxPriceNum
        {
            get => _maxPriceNum;
            set
            {
                _maxPriceNum = value;
                OnPropertyChanged();
            }
        }
        public bool isCheckPrice()
        {
            if ((MinPrice == null || MinPrice == "") && (MaxPrice == null || MaxPrice == ""))
            {
                return false;
            }
            MinPriceNum = (MinPrice == null || MinPrice == "") ? 0 : Int64.Parse(MinPrice);
            MaxPriceNum = (MaxPrice == null || MaxPrice == "") ? (Int64.MaxValue) : Int64.Parse(MaxPrice);
            if (MinPriceNum > MaxPriceNum)
            {
                return false;
            }
            return true;
        }
        public bool isCheckRating()
        {
            int i;
            for (i = 0; i < 6; i++)
            {
                if (CheckRatingStar[i] != 0)
                {
                    return true;
                }
            }
            return (i == 5) ? true : false;
        }
        public SearchFilterProductViewModel()
        {
            SearchValue = AccessUser.searchWd;
            FilterPrice = 0;
            ProductToList();
            BackCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Back();
            });
            Rating5Star = new RelayCommand<object>((p) =>
            {
                if (checkIndexRatingStar() == -1)
                {
                    return true;
                }
                if (checkIndexRatingStar() != 5)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                if (CheckRatingStar[5] == 1)
                {
                    FilterChanged = false;
                    CheckRatingStar[5] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[5] = 1;
                }
                NumCheckRating = 5;
            });
            Rating4Star = new RelayCommand<object>((p) =>
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
                    FilterChanged = false;
                    CheckRatingStar[4] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[4] = 1;
                }
                NumCheckRating = 4;
            });
            Rating3Star = new RelayCommand<object>((p) =>
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
                    FilterChanged = false;
                    CheckRatingStar[3] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[3] = 1;
                }
                NumCheckRating = 3;
            });
            Rating2Star = new RelayCommand<object>((p) =>
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
                    FilterChanged = false;
                    CheckRatingStar[2] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[2] = 1;
                }
                NumCheckRating = 2;
            });
            Rating1Star = new RelayCommand<object>((p) =>
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
                    FilterChanged = false;
                    CheckRatingStar[1] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[1] = 1;
                }
                NumCheckRating = 1;
            });
            Rating0Star = new RelayCommand<object>((p) =>
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
                    FilterChanged = false;
                    CheckRatingStar[0] = 0;
                }
                else
                {
                    FilterChanged = true;
                    CheckRatingStar[0] = 1;
                }
                NumCheckRating = 0;
            });
            ApplyCommand = new RelayCommand<object>((p) =>
            {
                return (isCheckPrice() || isCheckRating());
            }, (p) =>
            {
                FilterChanged = true;
                ListProductsWrapper = new ObservableCollection<PRODUCTWRAPPER>();
                foreach (PRODUCTWRAPPER product in ListProductsFilteredWrapper)
                {
                    if (isCheckPrice())
                    {
                        MinPriceNum = (MinPrice == null) ? 0 : Int64.Parse(MinPrice);
                        MaxPriceNum = (MaxPrice == null) ? (Int64.MaxValue) : Int64.Parse(MaxPrice);
                        if (product.Product.price >= MinPriceNum && product.Product.price <= MaxPriceNum)
                        {
                            if (isCheckRating())
                            {
                                if (product.RatingStar() == NumCheckRating)
                                {
                                    ListProductsWrapper.Add(product);
                                }
                            }
                            else
                            {
                                ListProductsWrapper.Add(product);
                            }
                        }
                    }
                    else
                    {
                        if (isCheckRating())
                        {
                            if (product.RatingStar() == NumCheckRating)
                            {
                                ListProductsWrapper.Add(product);
                            }
                        }
                    }
                }
            });
            ClearCommand = new RelayCommand<object>((p) =>
            {
                return FilterChanged;
            }, (p) =>
            {
                FilterChanged = false;
                FilterPrice = 0;
                ListProductsWrapper = ListProductsFilteredWrapper;
                NumCheckRating = 0;
                for (int i = 0; i < 6; i++)
                {
                    CheckRatingStar[i] = 0;
                }
                MinPrice = MaxPrice = null;
            });
            TopSalesCommand = new RelayCommand<object>((p) =>
            {
                if (ListProductsFilteredWrapper.Count == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                ObservableCollection<PRODUCTWRAPPER> ListProductsFilteredWrapperTemp = new ObservableCollection<PRODUCTWRAPPER>();
                ObservableCollection<ORDER> orders = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERS.Where(o => o.status == 3));
                if (isCheckPrice() || isCheckRating())
                {
                    ListProductsFilteredWrapperTemp = ListProductsWrapper;
                }
                else
                {
                    ListProductsFilteredWrapperTemp = ListProductsFilteredWrapper;
                }
                FilterChanged = true;
                if (FilterPrice != -1)
                {
                    FilterPrice = 1;
                    ListProductsWrapper = new ObservableCollection<PRODUCTWRAPPER>(ListProductsFilteredWrapperTemp.OrderByDescending(o => o.Sold));
                }
            });
            LatestCommand = new RelayCommand<object>((p) =>
            {
                if (ListProductsFilteredWrapper.Count == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                ObservableCollection<PRODUCTWRAPPER> ListProductsFilteredWrapperTemp = new ObservableCollection<PRODUCTWRAPPER>();
                ObservableCollection<ORDER> orders = new ObservableCollection<ORDER>(DataProvider.Ins.DB.ORDERS.Where(o => o.status == 3));
                if (isCheckPrice() || isCheckRating())
                {
                    ListProductsFilteredWrapperTemp = ListProductsWrapper;
                }
                else
                {
                    ListProductsFilteredWrapperTemp = ListProductsFilteredWrapper;
                }
                FilterChanged = true;
                if (FilterPrice != -1)
                {
                    FilterPrice = 1;
                    ListProductsWrapper = new ObservableCollection<PRODUCTWRAPPER>(ListProductsFilteredWrapperTemp.OrderByDescending(o => o.Product.id));
                }
            });
            LowToHighCommand = new RelayCommand<object>((p) =>
            {
                if (ListProductsFilteredWrapper.Count == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                ObservableCollection<PRODUCTWRAPPER> ListProductsFilteredWrapperTemp = new ObservableCollection<PRODUCTWRAPPER>();
                if (isCheckPrice() || isCheckRating())
                {
                    ListProductsFilteredWrapperTemp = ListProductsWrapper;
                }
                else
                {
                    ListProductsFilteredWrapperTemp = ListProductsFilteredWrapper;
                }
                FilterChanged = true;
                if (FilterPrice != -1)
                {
                    FilterPrice = -1;
                    ListProductsWrapper = new ObservableCollection<PRODUCTWRAPPER>(ListProductsFilteredWrapperTemp.OrderBy(o => o.Product.price));
                }
                OnPropertyChanged();
            });
            HighToLowCommand = new RelayCommand<object>((p) =>
            {
                if (ListProductsFilteredWrapper.Count == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                ObservableCollection<PRODUCTWRAPPER> ListProductsFilteredWrapperTemp = new ObservableCollection<PRODUCTWRAPPER>();
                if (isCheckPrice() || isCheckRating())
                {
                    ListProductsFilteredWrapperTemp = ListProductsWrapper;
                }
                else
                {
                    ListProductsFilteredWrapperTemp = ListProductsFilteredWrapper;
                }
                FilterChanged = true;
                if (FilterPrice != 1)
                {
                    FilterPrice = 1;
                    ListProductsWrapper = new ObservableCollection<PRODUCTWRAPPER>(ListProductsFilteredWrapperTemp.OrderByDescending(o => o.Product.price));
                }
                OnPropertyChanged();
            });


        }
    }
}