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
    public class UserManageViewModel:BaseViewModel
    {
        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People { get => _people; set { _people = value; OnPropertyChanged(); } }

        private Person _selectedPerson;
        public Person SelectedPerson { get => _selectedPerson; set { _selectedPerson = value; OnPropertyChanged(); } }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UserManageViewModel()
        {
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => { LoadPeopleData(); });
            SelectionChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                UserAccountDetail userAccountDetail = new UserAccountDetail(SelectedPerson);
                userAccountDetail.ShowDialog();
            });
        }
        void LoadPeopleData()
        {
            People = new ObservableCollection<Person>();
            var peopleList = DataProvider.ins.db.PEOPLE;
            foreach(var people in peopleList)
            {
                People.Add(people);
            }
        }
    }
}
