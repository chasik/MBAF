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
    
    public partial class data_exports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public data_exports()
        {
            this.data_exports_items = new HashSet<data_exports_items>();
        }
    
        public int data_exports_id { get; set; }
        public Nullable<int> data_exports_type_id { get; set; }
        public string data_exports_description { get; set; }
        public Nullable<System.DateTime> data_exports_date { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<byte> Delete_statute { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_exports_items> data_exports_items { get; set; }
    }
}
