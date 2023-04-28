using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    public class Product_order
    {
        public int id { get; set; }
        public string name { get; set; }
        public ORDER order { get; set; }
        public Product_order(int id, string name, ORDER order)
        {
            this.id = id;
            this.name = name;
            this.order = order;
        }
    }
}
