using E_Shopping.Model;
using E_Shopping.ViewModel;
using Firebase.Storage;
using Microsoft.Win32;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using File = System.IO.File;
using E_Shopping.PopUp;
using ProgressBar = E_Shopping.PopUp.ProgressBar;

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for EditProductUC.xaml
    /// </summary>
    public partial class EditProductUC : UserControl
    {
        public static PRODUCT getProsta { get; set; }
        public static PRODUCTTECHNICAL getProTechsta { get; set; }

        int imageCount = 1;
        String fileName1 { get; set; }
        FileStream stream1 { get; set; }

        String fileName2 { get; set; }
        FileStream stream2 { get; set; }

        String fileName3 { get; set; }
        FileStream stream3 { get; set; }

        String fileName4 { get; set; }
        FileStream stream4 { get; set; }

        String fileNameThumb { get; set; }
        FileStream streamThumb { get; set; }
        public EditProductUC()
        {
            InitializeComponent();
            this.DataContext = new EditProductViewModel();
        }

        private void oldRad_Checked(object sender, RoutedEventArgs e)
        {
            if (newCateTxb != null)
            {
                newCateTxb.IsEnabled = false;
                newCateTxb.IsHitTestVisible = false;
            }
            if (CateCB != null)
            {
                CateCB.IsHitTestVisible = true;
                CateCB.IsEnabled = true;
            }
        }

        private void newRad_Checked(object sender, RoutedEventArgs e)
        {
            if (newCateTxb != null)
            {
                newCateTxb.IsEnabled = true;
                newCateTxb.IsHitTestVisible = true;
            }
            if (CateCB != null)
            {
                CateCB.IsHitTestVisible = false;
                CateCB.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {
                if (imageCount % 4 == 1)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    fileName1 = openFileDialog.FileName;
                    stream1 = File.OpenRead(fileName1);
                    image1.Source = new BitmapImage(fileUri);
                    imageCount++;
                }
                else if (imageCount % 4 == 2)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    fileName2 = openFileDialog.FileName;
                    stream2 = File.OpenRead(fileName2);
                    image2.Source = new BitmapImage(fileUri);
                    imageCount++;
                }
                else if (imageCount % 4 == 3)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    fileName3 = openFileDialog.FileName;
                    stream3 = File.OpenRead(fileName3);
                    image3.Source = new BitmapImage(fileUri);
                    imageCount++;
                }
                else if (imageCount % 4 == 0)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    fileName4 = openFileDialog.FileName;
                    stream4 = File.OpenRead(fileName4);
                    image4.Source = new BitmapImage(fileUri);
                    imageCount++;
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            image1.Source = null;
            image2.Source = null;
            image3.Source = null;
            image4.Source = null;
            imageCount = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                fileNameThumb = openFileDialog.FileName;
                streamThumb = File.OpenRead(fileNameThumb);
                imageThumbnail.Source = new BitmapImage(fileUri);

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            imageThumbnail.Source = null;
        }

        private String nameImg(String s)
        {
            int i = s.LastIndexOf('\\');
            Random r = new Random();
            int num = r.Next(10000, 1000000000);
            s = s.Substring(i + 1, s.Length - i - 1);
            s = num.ToString() + s;
            return s;
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int flag = 1;
            if (txbName.Text == null || txbPrice.Text == null || txbProName.Text == null || txbWanTime.Text == null || txbMaterial.Text == null || txbFunc.Text == null || txbProDes.Text == null || txbQuantity.Text == null)
            {
                ValidationNotify validationNotify = new ValidationNotify("Not enough information");
                validationNotify.ShowDialog();
                return;
            }
            if (txbName.Text == "" || txbPrice.Text == "" || txbProName.Text == "" || txbWanTime.Text == "" || txbMaterial.Text == "" || txbFunc.Text == "" || txbProDes.Text == "" || txbQuantity.Text == "")
            {
                ValidationNotify validationNotify = new ValidationNotify("Not enough information");
                validationNotify.ShowDialog();
                return;
            }
            if ((CateCB.SelectedItem == null && (oldRad.IsChecked == true)) || ((newCateTxb.Text == null || newCateTxb.Text == "") && (newRad.IsChecked == true)) || ((oldRad.IsChecked == false) && (newRad.IsChecked == false)))
            {
                ValidationNotify validationNotify = new ValidationNotify("Not enough information");
                validationNotify.ShowDialog();
                return;
            }
            if (!checkInt(txbPrice.Text) || !checkInt(txbWanTime.Text) || !checkInt(txbQuantity.Text))
            {
                ValidationNotify validationNotify = new ValidationNotify("Price, warranty time and quantity must be a number");
                validationNotify.ShowDialog();
                return;
            }
            if (Int32.Parse(txbPrice.Text) < 0 || Int32.Parse(txbWanTime.Text) < 0 || Int32.Parse(txbQuantity.Text) < 0)
            {
                ValidationNotify validationNotify = new ValidationNotify("Price, warranty time and quantity equal or more than 0");
                validationNotify.ShowDialog();
                return;
            }

            var editPro = DataProvider.ins.db.PRODUCTs.Where(x => x.id == getProsta.id).SingleOrDefault();
            if (editPro != null)
            {
                if ((oldRad.IsChecked == true) && CateCB.SelectedItem != null)
                {
                    var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == CateCB.SelectedValue.ToString()).SingleOrDefault();
                    editPro.idCategory = cates.id;
                }
                else if ((newRad.IsChecked == true) && (newCateTxb.Text != null || newCateTxb.Text != ""))
                {
                    CATEGORY cATEGORY = new CATEGORY() { type = newCateTxb.Text };
                    DataProvider.ins.db.CATEGORies.Add(cATEGORY);
                    DataProvider.ins.db.SaveChanges();

                    var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == newCateTxb.Text).SingleOrDefault();
                    editPro.idCategory = cates.id;
                }
                else
                {
                    ValidationNotify validationNotify = new ValidationNotify("Not enough information");
                    validationNotify.ShowDialog();
                    return;
                }
                editPro.name = txbName.Text;
                editPro.price = Int32.Parse(txbPrice.Text);
                editPro.nameOfManufacturer = txbProName.Text;
                editPro.descriptionInformation = txbProDes.Text;
                DataProvider.ins.db.SaveChanges();
                var proTechnical = DataProvider.ins.db.PRODUCTTECHNICALs.Where(x => x.idProduct == editPro.id).SingleOrDefault();
                if (proTechnical != null)
                {
                    proTechnical.material = txbMaterial.Text;
                    proTechnical.uses = txbFunc.Text;
                    proTechnical.exps = Int32.Parse(txbWanTime.Text);
                    DataProvider.ins.db.SaveChanges();
                }

                var manageProSys = DataProvider.ins.db.MANAGEPRODUCTSYSTEMs.Where(x => x.idSP == editPro.id).SingleOrDefault();
                if (manageProSys != null)
                {
                    manageProSys.quantity = Int32.Parse(txbQuantity.Text);
                    DataProvider.ins.db.SaveChanges();
                }
            }


            ProgressBar progressBar = new ProgressBar();
            progressBar.Show();
            if (image1.Source != null)
            {
                if(fileName1 != null)
                {
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("productImages")
                    .Child(nameImg(fileName1))
                    .PutAsync(stream1, cancellation.Token);

                    try
                    {
                        String link1 = (await task);
                        var imagedb = DataProvider.ins.db.IMAGES.Where(x => x.idSP == editPro.id && x.title == "image1").SingleOrDefault();
                        if (imagedb != null)
                        {
                            imagedb.imageLink = link1;
                            DataProvider.ins.db.SaveChanges();
                        }
                        else
                        {
                            IMAGE iMAGE = new IMAGE() { idSP = editPro.id, title = "image1", imageLink = link1 };
                            DataProvider.ins.db.IMAGES.Add(iMAGE);
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 0;
                    }
                }
                

            }
            if (image2.Source != null)
            {
                if (fileName2 != null)
                {
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("productImages")
                    .Child(nameImg(fileName2))
                    .PutAsync(stream2, cancellation.Token);

                    try
                    {
                        String link2 = (await task);
                        var imagedb = DataProvider.ins.db.IMAGES.Where(x => x.idSP == editPro.id && x.title == "image2").SingleOrDefault();
                        if (imagedb != null)
                        {
                            imagedb.imageLink = link2;
                            DataProvider.ins.db.SaveChanges();
                        }
                        else
                        {
                            IMAGE iMAGE = new IMAGE() { idSP = editPro.id, title = "image2", imageLink = link2 };
                            DataProvider.ins.db.IMAGES.Add(iMAGE);
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 0;
                    }
                }
                

            }
            if (image3.Source != null)
            {
                if(fileName3 != null)
                {
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("productImages")
                    .Child(nameImg(fileName3))
                    .PutAsync(stream3, cancellation.Token);

                    try
                    {
                        String link3 = (await task);
                        var imagedb = DataProvider.ins.db.IMAGES.Where(x => x.idSP == editPro.id && x.title == "image3").SingleOrDefault();
                        if (imagedb != null)
                        {
                            imagedb.imageLink = link3;
                            DataProvider.ins.db.SaveChanges();
                        }
                        else
                        {
                            IMAGE iMAGE = new IMAGE() { idSP = editPro.id, title = "image3", imageLink = link3 };
                            DataProvider.ins.db.IMAGES.Add(iMAGE);
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 0;
                    }
                }
                

            }
            if (image4.Source != null)
            {
                if(fileName4 != null)
                {
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("productImages")
                    .Child(nameImg(fileName4))
                    .PutAsync(stream4, cancellation.Token);

                    try
                    {
                        String link4 = (await task);
                        var imagedb = DataProvider.ins.db.IMAGES.Where(x => x.idSP == editPro.id && x.title == "image4").SingleOrDefault();
                        if (imagedb != null)
                        {
                            imagedb.imageLink = link4;
                            DataProvider.ins.db.SaveChanges();
                        }
                        else
                        {
                            IMAGE iMAGE = new IMAGE() { idSP = editPro.id, title = "image4", imageLink = link4 };
                            DataProvider.ins.db.IMAGES.Add(iMAGE);
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 0;
                    }
                }
                

            }
            if (imageThumbnail.Source != null)
            {
                if(fileNameThumb != null)
                {
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("productImages")
                    .Child(nameImg(fileNameThumb))
                    .PutAsync(streamThumb, cancellation.Token);

                    try
                    {
                        String linkThumb = (await task);
                        var proThumb = DataProvider.ins.db.PRODUCTs.Where(x => x.id == editPro.id).SingleOrDefault();
                        if (proThumb != null)
                        {
                            proThumb.thumbnailimage = linkThumb;
                            DataProvider.ins.db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 0;
                    }
                }
                

            }

            if (flag == 0)
            {
                progressBar.Close();
                ValidationNotify validationNotify = new ValidationNotify("Failed to upload image");
                validationNotify.ShowDialog();
            }
            else
            {
                progressBar.Close();
                SucceedNotify succeedNotify = new SucceedNotify();
                succeedNotify.ShowDialog();
                MainViewModel.Instance.CurrentView = new ManageProductForOwnerViewModel();
            }
        }

        bool checkInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }
}
