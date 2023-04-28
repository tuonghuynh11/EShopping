using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Class
{
    public class ShoppingCart
    {
        public string name { get; set; }
        public string image { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string status { get; set; }

        public double total { get { 
            
                return price*quantity; 
            }
            
            set { 
        
            }
        }
        public Boolean check { get; set; }

        public ShoppingCart(string name, string image, int quantity, double price, bool check=false)
        {
            this.name = name;
            this.image = image;
            this.quantity = quantity;
            this.price = price;
            this.check = check;
        }
        public ShoppingCart() { }
    }
}
