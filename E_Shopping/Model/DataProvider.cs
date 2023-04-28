using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;

            }
            set { _ins = value; }
        }
       
        public E_ShOPPING_NEWEntities DB { get; set; }
        public E_ShOPPING_NEWEntities db { get; set; }
  
        private static DataProvider _Instance;
        public static DataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                }
                return _Instance;

            }
            set { _Instance = value; }
        }
        private DataProvider()
        {
            DB = new E_ShOPPING_NEWEntities();
            db = new E_ShOPPING_NEWEntities();
        }

     
        
    }
}
