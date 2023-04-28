using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Class
{
    public class Category
    {
        public string name { get; set; }
        public int id { get; set; }
        public bool check { get; set; }
        public Category()
        {
        }

        public Category(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
