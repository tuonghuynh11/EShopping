using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.ViewModel
{
    public class OrderedHistoryViewModel:BaseViewModel
    {

        //Danh sách đơn hàng đang mua
        private static ObservableCollection<ORDER> _buyingList;
        public ObservableCollection<ORDER> buyingList { get => _buyingList; set { _buyingList = value; OnPropertyChanged(); } }

        private static ObservableCollection<ORDER> _boughtList;
        //Danh sách các đơn hàng đã mua

        public ObservableCollection<ORDER> boughtList { get => _boughtList; set { _boughtList = value; OnPropertyChanged(); } }

        //Danh sách các danh mục của sản phẩm đã mua
        private static ObservableCollection<CATEGORY> _productCategory;
        public ObservableCollection<CATEGORY> productCategory { get => _productCategory; set { _productCategory = value; OnPropertyChanged(); } }
        public OrderedHistoryViewModel()
        {
            //id customer mốt sửa sau
            //Binding cho OrderedHistory
            int idcustomer = 1;
            int idCart=2;
            buyingList = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(p=>(p.status ==1 ||p.status==2) && p.idCart== idCart));



            boughtList = new ObservableCollection<ORDER>(DataProvider.ins.DB.ORDERS.Where(p=>p.status ==3 && p.idCart== idCart));

            productCategory = new ObservableCollection<CATEGORY>();
            var productCategoryReplace = boughtList
                .Join(DataProvider.ins.DB.CATEGORies,
                p => p.idProductType,
                e => e.id,
                (p, e) => new CATEGORY()
                {
                    id = e.id,
                    type = e.type,
                });
            var temp = productCategoryReplace.Select(m => m.type).Distinct();
            foreach (CATEGORY category in productCategoryReplace)
            {
                productCategory.Add(category);
            }
            productCategory.Add(new CATEGORY() { type = "ALL" });
        }
    }
}
