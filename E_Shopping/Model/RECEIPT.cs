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
    
    public partial class RECEIPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECEIPT()
        {
            this.LISTOFPRODUCTBUYs = new HashSet<LISTOFPRODUCTBUY>();
            this.ORDERSRECEIPTs = new HashSet<ORDERSRECEIPT>();
            this.ORDERSRECEIPTs1 = new HashSet<ORDERSRECEIPT>();
        }
    
        public int id { get; set; }
        public Nullable<int> idCustomer { get; set; }
        public Nullable<int> paymentInfo { get; set; }
        public Nullable<int> receiverInfo { get; set; }
        public Nullable<int> typeOfDelivery { get; set; }
        public Nullable<long> totalCost { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<long> saleValue { get; set; }
        public Nullable<int> idDiscount { get; set; }
    
        public virtual DELIVERY DELIVERY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTOFPRODUCTBUY> LISTOFPRODUCTBUYs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERSRECEIPT> ORDERSRECEIPTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERSRECEIPT> ORDERSRECEIPTs1 { get; set; }
        public virtual PAYMENTINFORMATION PAYMENTINFORMATION { get; set; }
        public virtual Person Person { get; set; }
        public virtual RECEIVERINFORMATION RECEIVERINFORMATION { get; set; }
    }
}
