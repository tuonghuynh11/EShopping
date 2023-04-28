using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class UploadProductViewModel:BaseViewModel
    {
        private ObservableCollection<string> _cateList;
        public ObservableCollection<string> CateList { get => _cateList; set { _cateList = value; OnPropertyChanged(); } }
        private string _name;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        private string _price;
        public string Price { get => _price; set { _price = value; OnPropertyChanged(); } }

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
        public UploadProductViewModel()
        {
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                CateList = new ObservableCollection<string>();
                var Cates = DataProvider.ins.db.CATEGORies;
                foreach (var Cate in Cates)
                {
                    CateList.Add(Cate.type);
                }
                Name = "";
                Price = "";
                ProducerName = "";
                WarrantyTime = "";
                Materital = "";
                Function = "";
                Description = "";
                NewCate = "";
                SelectedCate = "";
                OldCheked = false;
                NewCheked = false;
            });
                SaveCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                
                if (Name == null || Price == null || ProducerName == null || WarrantyTime == null || Materital == null || Function == null || Description == null)
                {
                    MessageBox.Show("thieu thong tin");
                    return;
                }
                if (Name == "" || Price == "" || ProducerName == "" || WarrantyTime == "" || Materital == "" || Function == "" || Description == "")
                    {
                    MessageBox.Show("thieu thong tin");
                    return;
                }
                if((SelectedCate == null && OldCheked) || (NewCate == null && NewCheked) || (!OldCheked && !NewCheked))
                {
                    MessageBox.Show("thieu thong tin");
                    return;
                }
                if (!checkInt(Price) || !checkInt(WarrantyTime))
                {
                    MessageBox.Show("Not a number");
                    return;
                }
                PRODUCT pRODUCT = new PRODUCT()
                {
                    name = Name,
                    nameOfManufacturer = ProducerName,
                    
                    price = Convert.ToInt32(Price),
                    descriptionInformation = Description,
                };
                if(OldCheked && SelectedCate!= null)
                {
                    var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == SelectedCate).SingleOrDefault();
                    pRODUCT.idCategory = cates.id;
                }
                else if(NewCheked && NewCate != null)
                {
                    CATEGORY cATEGORY = new CATEGORY() { type = NewCate };
                    DataProvider.ins.db.CATEGORies.Add(cATEGORY);
                    DataProvider.ins.db.SaveChanges();

                    var cates = DataProvider.ins.db.CATEGORies.Where(c => c.type == NewCate).SingleOrDefault();
                    pRODUCT.idCategory = cates.id;
                }
                DataProvider.ins.db.PRODUCTs.Add(pRODUCT);
                DataProvider.ins.db.SaveChanges();

                PRODUCTTECHNICAL pRODUCTTECHNICAL = new PRODUCTTECHNICAL()
                {
                    uses = Function,
                    exps = Convert.ToInt32(WarrantyTime),
                    material = Materital
                };
                var prd = DataProvider.ins.db.PRODUCTs.Where(x => x.id == pRODUCT.id).SingleOrDefault();
                pRODUCTTECHNICAL.idProduct = prd.id;
                DataProvider.ins.db.PRODUCTTECHNICALs.Add(pRODUCTTECHNICAL);
                DataProvider.ins.db.SaveChanges();
                MessageBox.Show("Upload done");
            });
            ResetCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                
            });
        }
        bool checkInt(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }
    }
}
