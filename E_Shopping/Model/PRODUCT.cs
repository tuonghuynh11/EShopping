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
    using System.Linq;

    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.IMAGES = new HashSet<IMAGE>();
            this.ORDERS = new HashSet<ORDER>();
            this.PRODUCTRATEs = new HashSet<PRODUCTRATE>();
            this.PRODUCTTECHNICALs = new HashSet<PRODUCTTECHNICAL>();
        }
        public string mainImage
        {
            get
            {
                IMAGE image = DataProvider.ins.DB.IMAGES.Where(p => p.idSP == this.id && p.title == "Thumnail").FirstOrDefault();
                //if(image.imageLink != null)
                //    return image.imageLink;
                return null;

            }
            set { }
        }
        public int id { get; set; }
        public string name { get; set; }
        public string nameOfManufacturer { get; set; }
        public string descriptionInformation { get; set; }
        public string technicalInformation { get; set; }
        public string thumbnailimage { get; set; }
        public Nullable<long> price { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> idCategory { get; set; }
    
        public virtual CATEGORY CATEGORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMAGE> IMAGES { get; set; }
        public virtual MANAGEPRODUCTSYSTEM MANAGEPRODUCTSYSTEM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTRATE> PRODUCTRATEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTTECHNICAL> PRODUCTTECHNICALs { get; set; }
    }
}
