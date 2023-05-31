using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Stripe;

namespace E_Shopping.ViewModel
{
    public class EditProductViewModel : BaseViewModel
    {
        public PRODUCT getPro { get; set; }
        public PRODUCTTECHNICAL getProTech { get; set; }

        public static PRODUCT getProsta { get; set; }
        public static PRODUCTTECHNICAL getProTechsta { get; set; }

        private ObservableCollection<string> _cateList;
        public ObservableCollection<string> CateList { get => _cateList; set { _cateList = value; OnPropertyChanged(); } }
        private string _name;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        private String _displayPath1;
        public String DisplayPath1 { get => _displayPath1; set { _displayPath1 = value; OnPropertyChanged(); } }

        private String _displayPath2;
        public String DisplayPath2 { get => _displayPath2; set { _displayPath2 = value; OnPropertyChanged(); } }

        private String _displayPath3;
        public String DisplayPath3 { get => _displayPath3; set { _displayPath3 = value; OnPropertyChanged(); } }

        private String _displayPath4;
        public String DisplayPath4 { get => _displayPath4; set { _displayPath4 = value; OnPropertyChanged(); } }

        private String _displayPathThumb;
        public String DisplayPathThumb { get => _displayPathThumb; set { _displayPathThumb = value; OnPropertyChanged(); } }


        private string _price;
        public string Price { get => _price; set { _price = value; OnPropertyChanged(); } }
        private string _quantity;
        public string Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); } }

        private string _producerName;
        public string ProducerName { get => _producerName; set { _producerName = value; OnPropertyChanged(); } }

        private string _warrantyTime;
        public string WarrantyTime { get => _warrantyTime; set { _warrantyTime = value; OnPropertyChanged(); } }

        private string _material;
        public string Materital { get => _material; set { _material = value; OnPropertyChanged(); } }

        private string _function;
        public string Function { get => _function; set { _function = value; OnPropertyChanged(); } }

        private string _description;
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }

        private string _newCate;
        public string NewCate { get => _newCate; set { _newCate = value; OnPropertyChanged(); } }

        private string _selectedCate;
        public string SelectedCate { get => _selectedCate; set { _selectedCate = value; OnPropertyChanged(); } }

        private bool _oldChecked;
        public bool OldCheked { get => _oldChecked; set { _oldChecked = value; OnPropertyChanged(); } }

        private bool _newChecked;
        public bool NewCheked { get => _newChecked; set { _newChecked = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        
        public EditProductViewModel(PRODUCT proDUCT, PRODUCTTECHNICAL proDUCTTECHNICAL)
        {
            getPro = proDUCT;
            getProTech = proDUCTTECHNICAL;

        }
        public EditProductViewModel()
        {
            
            CateList = new ObservableCollection<string>();
            var Cates = DataProvider.ins.db.CATEGORies;
            foreach (var Cate in Cates)
            {
                CateList.Add(Cate.type);
            }
            Name = getProsta.name;
            Price = getProsta.price.ToString();
            ProducerName = getProsta.nameOfManufacturer;
            WarrantyTime = getProTechsta.exps.ToString();
            Materital = getProTechsta.material;
            Function = getProTechsta.uses;
            Description = getProsta.descriptionInformation;
            NewCate = "";
            var proCate = DataProvider.ins.db.CATEGORies.Where(ct => ct.id == getProsta.idCategory).SingleOrDefault();
            if (proCate != null && CateList.Contains(proCate.type))
            {
                SelectedCate = proCate.type;
            }
            else
            {

                SelectedCate = "";
            }
            OldCheked = false;
            NewCheked = false;
            var managePro = DataProvider.ins.db.MANAGEPRODUCTSYSTEMs.Where(m => m.idSP == getProsta.id).SingleOrDefault();
            if(managePro != null)
            {
                Quantity = managePro.quantity.ToString();
            }

            var proEdit = DataProvider.ins.db.PRODUCTs.Where(x => x.id == getProsta.id).SingleOrDefault();
            if (proEdit != null)
            {
                if(proEdit.thumbnailimage == null)
                {
                    DisplayPathThumb = @"/Image/image.png";
                }
                else
                {
                    DisplayPathThumb = proEdit.thumbnailimage;
                }
            }
            var imagepro = DataProvider.ins.db.IMAGES.Where(x => x.idSP == getProsta.id);
            if(imagepro != null)
            {
                foreach(IMAGE img in imagepro)
                {
                    if(img.title == "image1")
                    {
                        DisplayPath1 = img.imageLink;
                    }
                    if (img.title == "image2")
                    {
                        DisplayPath2 = img.imageLink;
                    }
                    if (img.title == "image3")
                    {
                        DisplayPath3 = img.imageLink;
                    }
                    if (img.title == "image4")
                    {
                        DisplayPath4 = img.imageLink;
                    }
                }
            }
            //LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
            //    CateList = new ObservableCollection<string>();
            //    var Cates = DataProvider.ins.db.CATEGORies;
            //    foreach (var Cate in Cates)
            //    {
            //        CateList.Add(Cate.type);
            //    }
            //    Name = "";
            //    Price = "";
            //    ProducerName = "";
            //    WarrantyTime = "";
            //    Materital = "";
            //    Function = "";
            //    Description = "";
            //    NewCate = "";
            //    SelectedCate = "";
            //    OldCheked = false;
            //    NewCheked = false;
            //});
            SaveCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                //if (Name == null || Price == null || ProducerName == null || WarrantyTime == null || Materital == null || Function == null || Description == null || Quantity == null)
                //{
                //    MessageBox.Show("thieu thong tin");
                //    return;
                //}
                //if (Name == "" || Price == "" || ProducerName == "" || WarrantyTime == "" || Materital == "" || Function == "" || Description == "" || Quantity == "")
                //{
                //    MessageBox.Show("thieu thong tin");
                //    return;
                //}
                //if ((SelectedCate == null && OldCheked) || (NewCate == null && NewCheked) || (!OldCheked && !NewCheked))
                //{
                //    MessageBox.Show("thieu thong tin");
                //    return;
                //}
                //if (!checkInt(Price) || !checkInt(WarrantyTime) || !checkInt(Quantity))
                //{
                //    MessageBox.Show("Not a number");
                //    return;
                //}
                

                //var editPro = DataProvider.ins.db.PRODUCTs.Where(x => x.id == getProsta.id).SingleOrDefault();
                //if(editPro != null)
                //{
                //    if (OldCheked && SelectedCate != null)
                //    {
                //        var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == SelectedCate).SingleOrDefault();
                //        editPro.idCategory = cates.id;
                //    }
                //    else if (NewCheked && NewCate != null)
                //    {
                //        CATEGORY cATEGORY = new CATEGORY() { type = NewCate };
                //        DataProvider.ins.db.CATEGORies.Add(cATEGORY);
                //        DataProvider.ins.db.SaveChanges();

                //        var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == NewCate).SingleOrDefault();
                //        editPro.idCategory = cates.id;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Khong du thong tin");
                //        return;
                //    }
                //    editPro.name = Name;
                //    editPro.price = Int32.Parse(Price);
                //    editPro.nameOfManufacturer = ProducerName;
                //    editPro.descriptionInformation = Description;
                //    DataProvider.ins.db.SaveChanges();
                //    var proTechnical = DataProvider.ins.db.PRODUCTTECHNICALs.Where(x => x.idProduct == editPro.id).SingleOrDefault();
                //    if(proTechnical != null)
                //    {
                //        proTechnical.material = Materital;
                //        proTechnical.uses = Function;
                //        proTechnical.exps = Int32.Parse(WarrantyTime);
                //        DataProvider.ins.db.SaveChanges();
                //    }

                //    var manageProSys = DataProvider.ins.db.MANAGEPRODUCTSYSTEMs.Where(x => x.idSP == editPro.id).SingleOrDefault();
                //    if(manageProSys != null)
                //    {
                //        manageProSys.quantity = Int32.Parse(Quantity);
                //        DataProvider.ins.db.SaveChanges();
                //    }
                //}

                

                //MainViewModel.Instance.CurrentView = new ManageProductForOwnerViewModel();
            });
            ResetCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                //MainViewModel.Instance.CurrentView = new UploadProductViewModel();
            });
            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MainViewModel.Instance.CurrentView = new ManageProductForOwnerViewModel();
            });
        }
        
        bool checkInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }
}
