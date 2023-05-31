using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.UserControlBar;
using Stripe;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.WebRequestMethods;

namespace E_Shopping.ViewModel
{
    public class ManageProductForOwnerViewModel : BaseViewModel
    {


        //-----------------------------------them thumbnailimage vao trong PRODUCT
        private ObservableCollection<string> _listCate;
        public ObservableCollection<string> ListCate { get => _listCate; set { _listCate = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _listPage;
        public ObservableCollection<int> ListPage { get => _listPage; set { _listPage = value; OnPropertyChanged(); } }

        private ObservableCollection<PRODUCT> _listProduct;
        public ObservableCollection<PRODUCT> ListProduct { get => _listProduct; set { _listProduct = value; OnPropertyChanged(); } }

        private ObservableCollection<PRODUCT> _listAllProduct;
        public ObservableCollection<PRODUCT> ListAllProduct { get => _listAllProduct; set { _listAllProduct = value; OnPropertyChanged(); } }

        private ObservableCollection<PRODUCT> _listSortProduct;
        public ObservableCollection<PRODUCT> ListSortProduct { get => _listSortProduct; set { _listSortProduct = value; OnPropertyChanged(); } }

        private int _selectedPage;
        public int SelectedPage { get => _selectedPage; set { _selectedPage = value; OnPropertyChanged(); } }

        private string _selectedCate;
        public string SelectedCate { get => _selectedCate; set { _selectedCate = value; OnPropertyChanged(); } }

        private PRODUCT _selectedProduct;
        public PRODUCT SelectedProduct { get => _selectedProduct; set { _selectedProduct = value; OnPropertyChanged(); } }

        private String _displayImagePath;
        public String DisplayImagePath { get => _displayImagePath; set { _displayImagePath = value; OnPropertyChanged(); } }

        private bool _azChecked;
        public bool AZCheked { get => _azChecked; set { _azChecked = value; OnPropertyChanged(); } }

        private bool _zaChecked;
        public bool ZACheked { get => _zaChecked; set { _zaChecked = value; OnPropertyChanged(); } }

        private bool _highlowChecked;
        public bool HighLowCheked { get => _highlowChecked; set { _highlowChecked = value; OnPropertyChanged(); } }

        private bool _lowhighChecked;
        public bool LowHighCheked { get => _lowhighChecked; set { _lowhighChecked = value; OnPropertyChanged(); } }

        //private bool _noneChecked;
        //public bool NoneCheked { get => _noneChecked; set { _noneChecked = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand SortCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ManageProductForOwnerViewModel()
        {
            

            SelectedPage = 1;
            ListCate = new ObservableCollection<string>();
            var Categos = DataProvider.ins.db.CATEGORies;
            foreach (var Cate in Categos)
            {
                ListCate.Add(Cate.type);
            }
            ListCate.Add("(None)");
            ListPage = new ObservableCollection<int>();
            var listProducts = DataProvider.ins.db.PRODUCTs;
            Int32 numberOfProductss = listProducts.Count();
            Int32 lastPages = 0;
            if (numberOfProductss % 8 != 0)
                lastPages = 1;
            Int32 numberOfPagess = numberOfProductss / 8 + lastPages;
            for (int i = 1; i <= numberOfPagess; i++)
            {
                ListPage.Add(i);
            }

            ListAllProduct = new ObservableCollection<PRODUCT>();
            ListProduct = new ObservableCollection<PRODUCT>();
            var productss = DataProvider.ins.db.PRODUCTs;
            foreach (var pro in productss)
            {
                ListAllProduct.Add(pro);
            }
            int index1 = 1;
            foreach (var product in ListAllProduct)
            {
                if (index1 > 8)
                    break;

                if(product.thumbnailimage == null)
                {
                    product.thumbnailimage = @"/Image/image.png";
                }
                ListProduct.Add(product);
                
                index1++;
            }


            


            //LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
            //    SelectedPage = 1;
            //    ListCate = new ObservableCollection<string>();
            //    var Cates = DataProvider.ins.db.CATEGORies;
            //    foreach (var Cate in Cates)
            //    {
            //        ListCate.Add(Cate.type);
            //    }
            //    ListCate.Add("(None)");
            //    ListPage = new ObservableCollection<int>();
            //    var listProduct = DataProvider.ins.db.PRODUCTs;
            //    Int32 numberOfProducts = listProduct.Count();
            //    Int32 lastPage = 0;
            //    if (numberOfProducts % 8 != 0)
            //        lastPage = 1;
            //    Int32 numberOfPages = numberOfProducts / 8 + lastPage;
            //    for (int i = 1; i <= numberOfPages; i++)
            //    {
            //        ListPage.Add(i);
            //    }

            //    ListAllProduct = new ObservableCollection<PRODUCT>();
            //    ListProduct = new ObservableCollection<PRODUCT>();
            //    var products = DataProvider.ins.db.PRODUCTs;
            //    foreach(var pro in products)
            //    {
            //        ListAllProduct.Add(pro);
            //    }
            //    int index = 1;
            //    foreach (var product in ListAllProduct)
            //    {
            //        if (index > 8)
            //            break;
            //        ListProduct.Add(product);
            //        index++;
            //    }
            //});
            SelectionChangedCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => {
                ListProduct = new ObservableCollection<PRODUCT>();
                int index = 1;
                foreach (var product in ListAllProduct)
                {
                    if (index > 8 * SelectedPage)
                        break;
                    if(index > 8 * (SelectedPage - 1))
                    {
                        ListProduct.Add(product);
                        if (product.thumbnailimage == null)
                        {
                            product.thumbnailimage = @"/Image/image.png";
                        }
                        ListProduct.Add(product);
                    }
                    
                    index++;
                }
            });
            BackCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (SelectedPage == 1)
                    return;
                SelectedPage -= 1;
                ListProduct = new ObservableCollection<PRODUCT>();
                int index = 1;
                foreach (var product in ListAllProduct)
                {
                    if (index > 8 * SelectedPage)
                        break;
                    if (index > 8 * (SelectedPage - 1))
                    {
                        ListProduct.Add(product);
                        if (product.thumbnailimage == null)
                        {
                            product.thumbnailimage = @"/Image/image.png";
                        }
                        ListProduct.Add(product);
                    }

                    index++;
                }
            });
            NextCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                var listProduct = DataProvider.ins.db.PRODUCTs;
                Int32 numberOfProducts = listProduct.Count();
                Int32 lastPage = 0;
                if (numberOfProducts % 8 != 0)
                    lastPage = 1;
                Int32 numberOfPages = numberOfProducts / 8 + lastPage;
                if (SelectedPage == numberOfPages)
                    return;
                SelectedPage += 1;
                ListProduct = new ObservableCollection<PRODUCT>();
                int index = 1;
                foreach (var product in ListAllProduct)
                {
                    if (index > 8 * SelectedPage)
                        break;
                    if (index > 8 * (SelectedPage - 1))
                    {
                        ListProduct.Add(product);
                        if (product.thumbnailimage == null)
                        {
                            product.thumbnailimage = @"/Image/image.png";
                        }
                        ListProduct.Add(product);
                    }

                    index++;
                }
            });

            SortCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                

                var products = DataProvider.ins.db.PRODUCTs;
                ListAllProduct.Clear();
                foreach (var pro in products)
                {
                    ListAllProduct.Add(pro);
                }

                ListSortProduct = new ObservableCollection<PRODUCT>();
                if(SelectedCate != null && SelectedCate != "(None)")
                {
                    var cate = DataProvider.ins.db.CATEGORies.Where(c => c.type == SelectedCate).SingleOrDefault();
                    
                    if (cate != null)
                    {
                        foreach (var product in ListAllProduct)
                        {
                            if(product.idCategory == cate.id)
                            {
                                ListSortProduct.Add(product);
                            }
                        }
                        
                    }

                    
                }
                else if(SelectedCate == null || SelectedCate == "(None)")
                {
                    var productlist = DataProvider.ins.db.PRODUCTs;
                    foreach (var pro in productlist)
                    {
                        ListSortProduct.Add(pro);
                    }
                }
                if (AZCheked)
                {
                    ListSortProduct = new ObservableCollection<PRODUCT>(ListSortProduct.OrderBy(x => x.name).ToList());
                    
                }
                else if (ZACheked)
                {
                    ListSortProduct = new ObservableCollection<PRODUCT>(ListSortProduct.OrderByDescending(x => x.name).ToList());
                }
                else if (HighLowCheked)
                {
                    ListSortProduct = new ObservableCollection<PRODUCT>(ListSortProduct.OrderByDescending(x => x.price).ToList());
                    
                }
                else if (LowHighCheked)
                {
                    ListSortProduct = new ObservableCollection<PRODUCT>(ListSortProduct.OrderBy(x => x.price).ToList());
                }
                //else if (NoneCheked)
                //{
                //    ListSortProduct.Clear();
                    
                //    foreach (var pro in ListAllProduct)
                //    {

                //        ListSortProduct.Add(pro);
                //    }
                //}
                
                ListAllProduct = new ObservableCollection<PRODUCT>();
                ListAllProduct = ListSortProduct;
                ListPage.Clear();
                Int32 numberOfProducts = ListAllProduct.Count();
                Int32 lastPage = 0;
                if (numberOfProducts % 8 != 0)
                    lastPage = 1;
                Int32 numberOfPages = numberOfProducts / 8 + lastPage;
                for (int i = 1; i <= numberOfPages; i++)
                {
                    ListPage.Add(i);
                }
                SelectedPage = 1;
                ListProduct = new ObservableCollection<PRODUCT>();
                int index = 1;
                foreach (var product in ListAllProduct)
                {
                    if (index > 8)
                        break;
                    
                    if (product.thumbnailimage == null)
                    {
                        product.thumbnailimage = @"/Image/image.png";
                    }
                    ListProduct.Add(product);
                    index++;
                }
            });

            DeleteCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if(SelectedProduct == null)
                {
                    ValidationNotify validationNotify = new ValidationNotify("You need to choose 1 product");
                    validationNotify.ShowDialog();
                    return;
                }

                var proTech = DataProvider.ins.db.PRODUCTTECHNICALs.Where(pt => pt.idProduct == SelectedProduct.id).SingleOrDefault();
                if (proTech != null)
                {
                    
                    DataProvider.ins.db.PRODUCTTECHNICALs.Remove(proTech);
                    DataProvider.ins.db.SaveChanges();

                }

                var proManage = DataProvider.ins.DB.MANAGEPRODUCTSYSTEMs.Where(x => x.idSP == SelectedProduct.id).SingleOrDefault();
                if(proManage != null)
                {
                    DataProvider.ins.db.Database.ExecuteSqlCommand("delete from MANAGEPRODUCTSYSTEM where idsp = " + proManage.idSP.ToString());
                    //DataProvider.ins.db.MANAGEPRODUCTSYSTEMs.Remove(proManage);
                    DataProvider.ins.db.SaveChanges();
                }

                var product = DataProvider.ins.db.PRODUCTs.Where(pd => pd.id == SelectedProduct.id).SingleOrDefault();
                if (product != null)
                {

                    DataProvider.ins.db.PRODUCTs.Remove(product);
                    DataProvider.ins.db.SaveChanges();

                    
                    ListPage = new ObservableCollection<int>();
                    var listProduct = DataProvider.ins.db.PRODUCTs;
                    Int32 numberOfProducts = listProduct.Count();
                    Int32 lastPage = 0;
                    if (numberOfProducts % 8 != 0)
                        lastPage = 1;
                    Int32 numberOfPages = numberOfProducts / 8 + lastPage;
                    for (int i = 1; i <= numberOfPages; i++)
                    {
                        ListPage.Add(i);
                    }
                    SelectedPage = 1;
                    ListAllProduct = new ObservableCollection<PRODUCT>();
                    ListProduct = new ObservableCollection<PRODUCT>();
                    var products = DataProvider.ins.db.PRODUCTs;
                    foreach (var pro in products)
                    {
                        ListAllProduct.Add(pro);
                    }
                    int index = 1;
                    foreach (var pd in ListAllProduct)
                    {
                        if (index > 8)
                            break;
                        
                        if (product.thumbnailimage == null)
                        {
                            product.thumbnailimage = @"/Image/image.png";
                        }
                        ListProduct.Add(pd);
                        index++;
                    }

                    SucceedNotify succeedNotify = new SucceedNotify();
                    succeedNotify.ShowDialog();
                }
                
                
            });
            AddProductCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MainViewModel.Instance.CurrentView = new UploadProductViewModel();
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (SelectedProduct == null)
                {
                    ValidationNotify validationNotify = new ValidationNotify("You need to choose 1 product");
                    validationNotify.ShowDialog();
                    return;
                }
                var proTech = DataProvider.ins.db.PRODUCTTECHNICALs.Where(pt => pt.idProduct == SelectedProduct.id).SingleOrDefault();
                var product = DataProvider.ins.db.PRODUCTs.Where(pd => pd.id == SelectedProduct.id).SingleOrDefault();
                if(proTech != null && product != null)
                {
                    MainViewModel.Instance.CurrentView = new EditProductViewModel(product, proTech);

                    EditProductViewModel.getProsta = product;
                    EditProductViewModel.getProTechsta = proTech;
                    EditProductUC.getProsta = product;
                    EditProductUC.getProTechsta = proTech;
                    
                }
                else
                {
                    ValidationNotify validationNotify = new ValidationNotify("Failed to edit");
                    validationNotify.ShowDialog();
                    return;
                }
            });
        }
    }
}
