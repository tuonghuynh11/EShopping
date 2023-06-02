using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shopping.Model;
using DataProvider = E_Shopping.Model.DataProvider;

namespace E_Shopping.ViewModel
{
    
    public class ChartViewModel : BaseViewModel
    {
        private ObservableCollection<DataPoint> _ListOfGoods;
        public ObservableCollection<DataPoint> ListOfGoods { get => _ListOfGoods; set { _ListOfGoods = value; OnPropertyChanged(); } }
        private ObservableCollection<DataPoint> _ListRevenue;
        public ObservableCollection<DataPoint> ListRevenue { get => _ListRevenue; set { _ListRevenue = value; OnPropertyChanged(); } }

        public ChartViewModel()
        {
            ListOfGoods = new ObservableCollection<DataPoint>(DataProvider.ins.db.Database.SqlQuery<DataPoint>("select c.type as 'Argument', Count(p.id) As 'Value' from CATEGORY c LEFT JOIN PRODUCT p ON c.id = p.idCategory GROUP BY c.type"));
            ListRevenue = new ObservableCollection<DataPoint>(DataProvider.ins.db.Database.SqlQuery<DataPoint>("select CAST(MONTH(date) AS varchar) as 'Argument', CAST(SUM(coalesce(RECEIPT.totalCost, 0) + coalesce(RECEIPT.saleValue, 0)) AS int) as 'Value' from RECEIPT Where YEAR(date) = YEAR(GETDATE()) AND status = 1 group by MONTH(date)\r\n"));
        }
    }
    public class DataPoint
    {
        public string Argument { get; private set; }
        public int Value { get; private set; }
        ///Phải gán bằng tên 2 thuộc tính này
    }
}
