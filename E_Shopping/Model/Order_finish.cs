using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    public class Order_finish
    {
        public RECEIPT re { get; set; }
        public string CustomerName { get; set; }
        public string phoneNumber { get; set; }
        public Order_finish(RECEIPT re, string customerName, string phoneNumber)
        {
            this.re = re;
            CustomerName = customerName;
            this.phoneNumber = phoneNumber;
        }
    }
}
