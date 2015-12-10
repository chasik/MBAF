//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mba_old_model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.CxA = new HashSet<CxA>();
            this.PxA = new HashSet<PxA>();
        }
    
        public int Address_id { get; set; }
        public string Address_street { get; set; }
        public string Address_street2 { get; set; }
        public string Address_village { get; set; }
        public string Address_city { get; set; }
        public string Address_zip { get; set; }
        public string Address_Country { get; set; }
        public string Address_District { get; set; }
        public string Address_Region { get; set; }
        public Nullable<byte> Address_statute { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public byte Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public Nullable<int> address_id_dedupl { get; set; }
        public Nullable<int> idprojectcontact { get; set; }
        public Nullable<int> sk_priority { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CxA> CxA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PxA> PxA { get; set; }
    }
}
