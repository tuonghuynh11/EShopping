using E_Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shopping.Model;

namespace E_Shopping.Class
{
    class AccessUser
    {
        public static Person currentUser { get; set; }
        public static string searchWd { get; set; }
    }
}
