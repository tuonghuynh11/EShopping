using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class ManageGiftCodeViewModel:BaseViewModel
    {
        private ObservableCollection<Person> _personList;
        public ObservableCollection<Person> PersonList { get => _personList; set { _personList = value; OnPropertyChanged(); } }

        private Person _selectedPerson;
        public Person SelectedPerson { get => _selectedPerson; set { _selectedPerson = value; OnPropertyChanged(); } }

        private ObservableCollection<DISCOUNT> _discountList;
        public ObservableCollection<DISCOUNT> DiscountList { get => _discountList; set { _discountList = value; OnPropertyChanged(); } }



        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ManageGiftCodeViewModel()
        {
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => { LoadPersonData(); });
            SelectionChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                DiscountList = new ObservableCollection<DISCOUNT>();
                if (SelectedPerson != null)
                    LoadDiscountData(SelectedPerson);
            });
            ConfirmCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Person temp = SelectedPerson;
                if (temp != null)
                {
                    AddNewGiftCode addNewGiftCode = new AddNewGiftCode(temp.id);
                    addNewGiftCode.ShowDialog();
                    LoadDiscountData(temp);
                }


            });
            CancelCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                

            });
        }
        void LoadPersonData()
        {
            PersonList = new ObservableCollection<Person>(DataProvider.ins.db.PEOPLE);
            if (PersonList.Count!=0)
            {
                SelectedPerson = PersonList[0];
                LoadDiscountData(SelectedPerson);
            }

        }
      
        void LoadDiscountData(Person co)
        {
            DiscountList = new ObservableCollection<DISCOUNT>(DataProvider.ins.db.DISCOUNTs.Where(p=>p.idCustomer==co.id));

        }
    }
}

