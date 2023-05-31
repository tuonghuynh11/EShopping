using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace E_Shopping.Convert
{
    public class ConvertStringToCurrency: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currency = "";
            if (value != null)
            {
                currency = String.Format("{0:n0}VND", double.Parse(value.ToString()));
            }
            return currency;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
