//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Shopping.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISCOUNT
    {
        public int id { get; set; }
        public Nullable<int> idCustomer { get; set; }
        public string code { get; set; }
        public Nullable<long> value { get; set; }
        public Nullable<System.DateTime> exp_time { get; set; }
        public string status { get; set; }
        public string isExpire
        {
            get
            {
                if (this.exp_time >= DateTime.Today)
                {
                    return "Unexpired";
                }
                return "Expired";
            }
            set
            {

            }
        }
        public virtual Person Person { get; set; }
    }
}
