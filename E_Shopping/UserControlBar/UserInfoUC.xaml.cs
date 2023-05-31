using E_Shopping.Model;
using E_Shopping.ViewModel;
using Firebase.Storage;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using E_Shopping.PopUp;
using ProgressBar = E_Shopping.PopUp.ProgressBar;

namespace E_Shopping.UserControlBar
{
    /// <summary>
    /// Interaction logic for UserInfoUC.xaml
    /// </summary>
    public partial class UserInfoUC : UserControl
    {
        String fileName { get; set; }
        FileStream stream1 { get; set; }
        public UserInfoUC()
        {
            InitializeComponent();
            this.DataContext = new UserInfoViewModel();

            
            //avatarImg.Source = new BitmapImage(new Uri(@"/Image/Avatar.jpeg", UriKind.RelativeOrAbsolute));

            //var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
            //if(user != null)
            //{
            //    if(user.avatar != null)
            //    {
            //        var uri = new Uri(user.avatar);
                    
            //        var bitmap = new BitmapImage(uri);
            //        avatarImg.Source = bitmap;
            //    }
            //}
        }

        private void Editbtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Visible;
            Cancelbtt.Visibility = Visibility.Visible;
            Editbtt.Visibility = Visibility.Hidden;
            Nametb.IsReadOnly = false;
            addresstb.IsReadOnly = false;
            Phonetb.IsReadOnly = false;
            Emailtb.IsReadOnly = false;
            CardNumtb.IsReadOnly = false;
            cardTypetb.Visibility = Visibility.Hidden;
            cbCardType.Visibility = Visibility.Visible;
            genderTB.Visibility = Visibility.Hidden;
            cbGender.Visibility = Visibility.Visible;
            dpDob.Visibility = Visibility.Visible;
            dobtb.Visibility = Visibility.Hidden;
            uploadBtt.IsHitTestVisible = true;
        }

        private void Cancelbtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Hidden;
            Cancelbtt.Visibility = Visibility.Hidden;
            Editbtt.Visibility = Visibility.Visible;
            Nametb.IsReadOnly = true;
            addresstb.IsReadOnly = true;
            Phonetb.IsReadOnly = true;
            Emailtb.IsReadOnly = true;
            CardNumtb.IsReadOnly = true;
            cardTypetb.Visibility = Visibility.Visible;
            cbCardType.Visibility = Visibility.Hidden;
            genderTB.Visibility = Visibility.Visible;
            cbGender.Visibility = Visibility.Hidden;
            dpDob.Visibility = Visibility.Hidden;
            dobtb.Visibility = Visibility.Visible;
            uploadBtt.IsHitTestVisible = false;
        }

        private async void Savebtt_Click(object sender, RoutedEventArgs e)
        {
            Savebtt.Visibility = Visibility.Hidden;
            Cancelbtt.Visibility = Visibility.Hidden;
            Editbtt.Visibility = Visibility.Visible;
            Nametb.IsReadOnly = true;
            addresstb.IsReadOnly = true;
            Phonetb.IsReadOnly = true;
            Emailtb.IsReadOnly = true;
            CardNumtb.IsReadOnly = true;
            cardTypetb.Visibility = Visibility.Visible;
            cbCardType.Visibility = Visibility.Hidden;
            genderTB.Visibility = Visibility.Visible;
            cbGender.Visibility = Visibility.Hidden;
            dpDob.Visibility = Visibility.Hidden;
            dobtb.Visibility = Visibility.Visible;
            uploadBtt.IsHitTestVisible = false;

            if (avatarImg.Source == null)
            {
                //MessageBox.Show("Khong co");
            }
            else
            {
                if (fileName != null)
                {
                    //var stream = File.Open(fileName, FileMode.Open);
                    var cancellation = new CancellationTokenSource();
                    var task = new FirebaseStorage("e-shop-af11b.appspot.com", new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                    .Child("avatars")
                    .Child(nameImg(fileName))
                    .PutAsync(stream1, cancellation.Token);

                    try
                    {
                        ProgressBar progressBar = new ProgressBar();
                        progressBar.Show();
                        String link = await task;
                        var user = DataProvider.ins.db.PEOPLE.Where(x => x.userName == LoginViewModel.AppUser).SingleOrDefault();
                        if (user != null)
                        {
                            user.avatar = link;
                            DataProvider.ins.db.SaveChanges();
                        }
                        progressBar.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
                
                //MessageBox.Show("done");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
                stream1 = File.OpenRead(fileName);
                avatarImg.Source = new BitmapImage(fileUri);

            }
        }

        private String nameImg(String s)
        {
            int i = s.LastIndexOf('\\');
            Random r = new Random();
            int num = r.Next(10000, 1000000000);
            s = s.Substring(i + 1, s.Length - i - 1 );
            s = num.ToString() + s;
            return s;
        }
    }
}
