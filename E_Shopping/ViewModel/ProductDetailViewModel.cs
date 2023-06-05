using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PasswordEncode;
using E_Shopping.PopUp;
using E_Shopping.UserControlBar;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace E_Shopping.ViewModel
{
    public class ProductDetailViewModel : BaseViewModel
    {
        SucceedNotify succeedNotify = new SucceedNotify();
        private static ObservableCollection<ORDER> _shoppingCarts;
        private ORDER _order;
        private PRODUCT _product;
        private PRODUCTWRAPPER _productWrapper;
        public static Stack<object> stackView = new Stack<object>();
        private static MainViewModel _Instance;
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
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
        public static void removeViewToStack()
        {
            stackView.Pop();
            Instance.CurrentView = stackView.Peek();
        }
        public ORDER Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ORDER> shoppingCarts { get => _shoppingCarts; set { _shoppingCarts = value; OnPropertyChanged(); } }
        public PRODUCT Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        public PRODUCTWRAPPER ProductWrapper
        {
            get => _productWrapper;
            set
            {
                _productWrapper = value;
                OnPropertyChanged();
            }
        }
        
        #region comands
        public ICommand BuyItNowCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DecreaseQuantityCommand { get; set; }
        public ICommand preImageCommand { get; set; }
        public ICommand nextImageCommand { get; set; }
        public ICommand BackCommand { get; set; }

        #endregion
        public void Back()
        {
            MainViewModel.stackView.Pop();
            MainViewModel.Instance.CurrentView = MainViewModel.stackView.Peek();
        }
        private string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
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
        private string reviews;
        public string Reviews
        {
            get => reviews;
            set
            {
                reviews = value;
                OnPropertyChanged();
            }
        }
        private string descriptionInformation;
        public string DescriptionInformation
        {
            get => descriptionInformation;
            set
            {
                descriptionInformation = value;
                OnPropertyChanged();
            }
        }
        private string technicalInformation;
        public string TechnicalInformation
        {
            get => technicalInformation;
            set
            {
                technicalInformation = value;
                OnPropertyChanged();
            }
        }
        private string ratingStarImage;
        public string RatingStarImage
        {
            get => ratingStarImage;
            set
            {
                ratingStarImage = value;
                OnPropertyChanged();
            }
        }
        private string price;
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        private string categoryProduct;
        public string CategoryProduct
        {
            get => categoryProduct;
            set
            {
                categoryProduct = value;
                OnPropertyChanged();
            }
        }
        private string rating;
        public string Rating
        {
            get => rating;
            set
            {
                rating = value;
                OnPropertyChanged();
            }
        }
        private string brand;
        public string Brand
        {
            get => brand;
            set
            {
                brand = value;
                OnPropertyChanged();
            }
        }
        private static int _quantityProduct;
        public static int QuantityProduct
        {
            get => _quantityProduct;
            set
            {
                _quantityProduct = value;
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
        private List<IMAGE> _images;
        public List<IMAGE> Images
        {
            get => _images; 
            set
            {
                _images = value;
                OnPropertyChanged();
            }
        }
        private string numOf5Star;
        public string NumOf5Star
        {
            get => numOf5Star;
            set
            {
                numOf5Star = value;
                OnPropertyChanged();
            }
        }
        private string numOf4Star;
        public string NumOf4Star
        {
            get => numOf4Star;
            set
            {
                numOf4Star = value;
                OnPropertyChanged();
            }
        }
        private string numOf3Star;
        public string NumOf3Star
        {
            get => numOf3Star;
            set
            {
                numOf3Star = value;
                OnPropertyChanged();
            }
        }
        private string numOf2Star;
        public string NumOf2Star
        {
            get => numOf2Star;
            set
            {
                numOf2Star = value;
                OnPropertyChanged();
            }
        }
        private string numOf1Star;
        public string NumOf1Star
        {
            get => numOf1Star;
            set
            {
                numOf1Star = value;
                OnPropertyChanged();
            }
        }
        private int _currentIndexImage = 0;
        public int CurrentIndexImage
        {
            get => _currentIndexImage;
            set
            {
                _currentIndexImage = value;
                OnPropertyChanged();
            }
        }
        private BitmapImage _currentImage;
        public BitmapImage CurrentImage
        {
            get => _currentImage; 
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }
        private int calculateRating(PRODUCT product)
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
            return ratingTemp;
        }
        private string RatingImage(PRODUCT product)
        {
            int ratingTemp = calculateRating(product);

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
        private BitmapImage ConvertImageLinkToBitMapImage(string imageLink)
        {
            return new BitmapImage(new Uri(imageLink));
        }
        private void CountRatingStar(PRODUCT product)
        {
            ObservableCollection<PRODUCTRATE> listProductRate = new ObservableCollection<PRODUCTRATE>(DataProvider.Ins.DB.PRODUCTRATEs);
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
            foreach (PRODUCTRATE prodRate in listProductRate)
            {
                if (prodRate.idProduct.Equals(product.id))
                {
                    switch (prodRate.rate)
                    {
                        case 1:
                            count1++;
                            break;
                        case 2:
                            count2++;
                            break;
                        case 3:
                            count3++;
                            break;
                        case 4:
                            count4++;
                            break;
                        case 5:
                            count5++;
                            break;
                        default:
                            break;
                    }
                }
            }
            NumOf1Star = count1.ToString();
            NumOf2Star = count2.ToString();
            NumOf3Star = count3.ToString();
            NumOf4Star = count4.ToString();
            NumOf5Star = count5.ToString();
        }
        public ProductDetailViewModel() { }
        public ProductDetailViewModel(PRODUCT product) {
            Images = new List<IMAGE>();
            ObservableCollection<PRODUCT> listProduct = new ObservableCollection<PRODUCT>(DataProvider.Ins.DB.PRODUCTs);
            Product = product;
            //Product = listProduct.First();
            //Product = DataProvider.Ins.DB.PRODUCTs.Where((p) => p.id == 3).FirstOrDefault();
            CATEGORY category = DataProvider.Ins.DB.CATEGORies.Where((p) => p.id == Product.idCategory).FirstOrDefault();
            MANAGEPRODUCTSYSTEM manageProductSystem = DataProvider.Ins.DB.MANAGEPRODUCTSYSTEMs.Where((p) => p.idSP == Product.id).FirstOrDefault();
            ProductWrapper = new PRODUCTWRAPPER()
            {
                Product = Product,
                MainImage = new BitmapImage(new Uri(product.thumbnailimage)),
                CustomPrice = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", Product.price),
                RatingStarImage = RatingImage(Product),
                NameCategory = category.type,
            };
            CountRatingStar(Product);
            foreach (IMAGE img in ProductWrapper.Product.IMAGES)
            {
                Images.Add(img);
            }
            if (Images.Count == 0)
            {
                IMAGE img = new IMAGE()
                {
                    idSP = Product.id,
                    title = "Thumnail",
                    imageLink = Product.thumbnailimage,
                };
                Images.Add(img);
            }
            Name = ProductWrapper.Product.name;
            Id = ProductWrapper.Product.id.ToString();
            Price = ProductWrapper.CustomPrice;
            Rating = (calculateRating(ProductWrapper.Product)).ToString();
            Reviews = calculateRating(ProductWrapper.Product).ToString();
            RatingStarImage = ProductWrapper.RatingStarImage;
            CategoryProduct = ProductWrapper.NameCategory;
            CurrentImage = ConvertImageLinkToBitMapImage(Images.First().imageLink);
            Brand = ProductWrapper.Product.nameOfManufacturer;
            QuantityProduct = (Product.status == 0) ? 0 : (int)manageProductSystem.quantity;
            DescriptionInformation = ProductWrapper.Product.descriptionInformation;
            TechnicalInformation = ProductWrapper.Product.technicalInformation;
            //
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
            //shoppingCarts = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(p => p.idCart == person.idCart && p.status == 0));
            BuyItNowCommand = new RelayCommand<object>((p) =>
            {
                if (QuantityProduct < 1 || Int32.Parse(QuantityTextBox) < 1)
                {
                    return false; 
                }
                return true;
            }, (p) =>
            {
                Order = new ORDER()
                {
                    idCart = AccessUser.currentUser.idCart,
                    idProduct = ProductWrapper.Product.id,
                    quantity = Int32.Parse(QuantityTextBox),
                    date = DateTime.Now,
                    status = 0,
                };
                if (Order.status != null)
                {
                    
                    try
                    {
                        DataProvider.ins.db.ORDERS.Add(Order);
                        DataProvider.ins.db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.InnerException.Message);
                    }
                   
                    MainViewModel.Instance.CurrentView = new CartViewModel();
                    MainViewModel.stackView.Push(MainViewModel.Instance.CurrentView);
                }
            });
            AddToCartCommand = new RelayCommand<object>((p) =>
            {
                if (QuantityProduct < 1 || Int32.Parse(QuantityTextBox) < 1)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                Order = new ORDER()
                {
                    idCart = AccessUser.currentUser.idCart,
                    idProduct = ProductWrapper.Product.id,
                    quantity = Int32.Parse(QuantityTextBox),
                    status = 0,
                };
                if (Order.status != null)
                {
                    
                    DataProvider.ins.DB.ORDERS.Add(Order);
                    DataProvider.ins.DB.SaveChanges();
                    
                    succeedNotify.content.Text = "Added To Cart";
                    succeedNotify.content.FontSize = 20;
                    succeedNotify.ShowDialog();
                }
            });
            preImageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (CurrentIndexImage < Images.Count && CurrentIndexImage > 0)
                {
                    CurrentImage = ConvertImageLinkToBitMapImage(Images[--CurrentIndexImage].imageLink);
                }
                else
                {
                    CurrentIndexImage = Images.Count - 1;
                    CurrentImage = ConvertImageLinkToBitMapImage(Images[CurrentIndexImage].imageLink);
                }
            });
            nextImageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (CurrentIndexImage < Images.Count - 1)
                    CurrentImage = ConvertImageLinkToBitMapImage(Images[++CurrentIndexImage].imageLink);
                else
                {
                    CurrentIndexImage = 0;
                    CurrentImage = ConvertImageLinkToBitMapImage(Images[CurrentIndexImage].imageLink);
                }
            });
            BackCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Back();
            });
        }
        
    }
}
