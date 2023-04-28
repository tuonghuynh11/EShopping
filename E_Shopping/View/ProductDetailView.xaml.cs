using E_Shopping.Model;
using E_Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace E_Shopping.View
{
    /// <summary>
    /// Interaction logic for ProductDetailView.xaml
    /// </summary>
    public partial class ProductDetailView : UserControl
    {
        private List<IMAGE> _images;
        private int _currentIndexImage = 0;
        private BitmapImage _currentImage;
        private HashSet<PRODUCTRATE> _productRate;
        public ProductDetailView(/*PRODUCT selectedProduct*/)
        {
            InitializeComponent();
            /*this.DataContext = new ProductDetailViewModel(selectedProduct.id);*/
            _images = new List<IMAGE>();
            IMAGE image1 = new IMAGE();
            image1.imageLink = "https://cdn.tgdd.vn/Products/Images/42/251192/iphone-14-pro-max-den-thumb-600x600.jpg";
            IMAGE image2 = new IMAGE();
            image2.imageLink = "https://cdn2.cellphones.com.vn/x358,webp,q100/media/catalog/product/3/_/3_225.jpg";
            IMAGE image3 = new IMAGE();
            image3.imageLink = "https://cdn1.viettelstore.vn/images/Product/ProductImage/medium/1992615027.jpeg";
            _images.Add(image1);
            _images.Add(image2);
            _images.Add(image3);

            _currentImage = new BitmapImage();
            _currentIndexImage = 0;

            _productRate = new HashSet<PRODUCTRATE>();
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
            var uriSource = new Uri($@"/E_Shopping;component{rateImageSource}", UriKind.Relative);
            RateImageSource.Source = new BitmapImage(uriSource);
            RateImageSource2.Source = new BitmapImage(uriSource);
            Rating.Text = Rating2.Text = averageProductRating.ToString();
        }
        private BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage img = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageByteArray))
            {
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = memStream;
                img.EndInit();
                img.Freeze();
            }
            return img;
        }
        private BitmapImage ConvertImageLinkToBitMapImage(string imageLink)
        {
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(imageLink);
                return ConvertByteArrayToBitMapImage(imageBytes);
            }
        }
        private void preImage_Click(Object sender, RoutedEventArgs e)
        {
            if (_currentIndexImage < _images.Count && _currentIndexImage > 0)
            {
                imageProduct.ImageSource = ConvertImageLinkToBitMapImage(_images[--_currentIndexImage].imageLink);
            }
            else
            {
                _currentIndexImage = _images.Count - 1;
                imageProduct.ImageSource = ConvertImageLinkToBitMapImage(_images[_currentIndexImage].imageLink);
            }
        }
        private void nextImage_Click(Object sender, RoutedEventArgs e)
        {
            if (_currentIndexImage < _images.Count - 1)
                imageProduct.ImageSource = ConvertImageLinkToBitMapImage(_images[++_currentIndexImage].imageLink);
            else
            {
                _currentIndexImage = 0;
                imageProduct.ImageSource = ConvertImageLinkToBitMapImage(_images[_currentIndexImage].imageLink);
            }
        }
    }
}
