using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    internal class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
        }

        public E_ShOPPING_NEWEntities DB { get; set; }

        private DataProvider()
        {
            DB = new E_ShOPPING_NEWEntities();
        }
    }
}
