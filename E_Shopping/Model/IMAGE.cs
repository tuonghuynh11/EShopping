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
    
    public partial class IMAGE
    {
        public int id { get; set; }
        public int idSP { get; set; }
        public string imageLink { get; set; }
        public string title { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
