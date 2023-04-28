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

namespace E_Shopping.ViewModel
{
    internal class CategoryViewModel:BaseViewModel
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        private ObservableCollection<CATEGORY> cATEGORies;
        public ObservableCollection<CATEGORY> CATEGORies
        {
            get { return cATEGORies; }
            set { cATEGORies = value;  OnPropertyChanged(); }
        }
        private ObservableCollection<PRODUCT> items;
        
       public ObservableCollection<PRODUCT> Items { get { return items; } set { items = value; OnPropertyChanged(); } }

        private CATEGORY selectedcat;
        public CATEGORY SelectedCategory { get { return selectedcat; } set { selectedcat = value; OnPropertyChanged(); } }
        public CategoryViewModel()
        {
            cATEGORies = new ObservableCollection<CATEGORY>(DataProvider.ins.DB.CATEGORies);
            items = new ObservableCollection<PRODUCT>(DataProvider.ins.DB.PRODUCTs);
            
            
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

