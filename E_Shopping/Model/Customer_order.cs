using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    public class Customer_order
    {
        public ORDER order { get; set; }
        public string CustomerName { get; set; }
        public Customer_order(ORDER order, string customerName)
        {
            this.order = order;
            CustomerName = customerName;
        }
    }
}
