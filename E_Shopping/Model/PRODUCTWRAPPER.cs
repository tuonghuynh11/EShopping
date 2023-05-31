using E_Shopping.ViewModel;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace E_Shopping.Model
{
    public class PRODUCTWRAPPER : BaseViewModel
    {
        private PRODUCT _product;
        public PRODUCT Product { get => _product; set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        private string _customPrice;
        public string CustomPrice
        {
            get => _customPrice;
            set
            {
                _customPrice = value;
                OnPropertyChanged();
            }
        }
        public BitmapImage _mainImage;
        public BitmapImage MainImage
        {
            get => _mainImage; 
            set
            {
                _mainImage = value;
                OnPropertyChanged();
            }
        }
        public int RatingStar()
        {
            int ratingTemp = 0, count = 0;
            ObservableCollection<PRODUCTRATE> listProductRate = new ObservableCollection<PRODUCTRATE>(DataProvider.Ins.DB.PRODUCTRATEs);
            foreach (PRODUCTRATE prodRate in listProductRate)
            {
                if (prodRate.idProduct.Equals(_product.id))
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
        private string _ratingStarImage = "/Assets/Images/Star_rating_0_of_5.png";
        public string RatingStarImage
        {
            get
            {
                return _ratingStarImage;
            }
            set
            {
                _ratingStarImage = value;
                OnPropertyChanged();
            }
        }
        private string _nameCategory;
        public string NameCategory
        {
            get => _nameCategory;
            set
            {
                _nameCategory = value;
                OnPropertyChanged();
            }
        }
    }
}
