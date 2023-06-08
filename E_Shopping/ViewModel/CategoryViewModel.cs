using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using E_Shopping.Model;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using E_Shopping.Class;
using System.Windows;
using E_Shopping.UserControlBar;

namespace E_Shopping.ViewModel
{
    internal class CategoryViewModel:BaseViewModel
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public ICommand CategoryClick;
        
        private ObservableCollection<CATEGORY> cATEGORies;
        public ObservableCollection<CATEGORY> CATEGORies
        {
            get { return cATEGORies; }
            set { cATEGORies = value;  OnPropertyChanged(); }
        }
        private List<PRODUCT> items;
        
       public List<PRODUCT> Items { get { return items; } set { items = value; OnPropertyChanged(); } }
        private List<PRODUCT> latestItems;
        public List<PRODUCT> LatestItems { get { return latestItems; } set { latestItems = value; OnPropertyChanged(); } }
        private List<PRODUCT> randomItems;
        public List<PRODUCT> RandomItems { get { return randomItems; } set { randomItems = value; OnPropertyChanged(); } }


        private CATEGORY selectedcat;
        public CATEGORY SelectedCategory { get { return selectedcat; } set { selectedcat = value; OnPropertyChanged(); } }
        public CategoryViewModel()
        {
            cATEGORies = new ObservableCollection<CATEGORY>(DataProvider.ins.DB.CATEGORies);
            items = DataProvider.ins.DB.PRODUCTs.OrderByDescending(u=> u.ORDERS.Count).Take(4).ToList();
            latestItems = DataProvider.ins.DB.PRODUCTs.OrderByDescending(u => u.id).Take(4).ToList();
            randomItems = DataProvider.ins.DB.PRODUCTs.OrderBy(u => Guid.NewGuid()).Take(8).ToList();

            CategoryClick = new RelayCommand<DashboardUC>((p) => { return p != null ? true : false; },
                (p) =>
                {
                   
                    AccessUser.searchWd = SelectedCategory.type;
                    MainViewModel.Instance.CurrentView = new SearchFilterProductViewModel();
                }
                );
            
            
        }
        
        
       
        
    }
    
    public class Item
    {
        public string Title { get; set; }  
        public string ImageData { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
        public Item(string title, string imageTitle, long price)
        {
            Title = title;
            ImageData = imageTitle;
            Price = price;
        }
    }
}

