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
    
    public partial class report_data_template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public report_data_template()
        {
            this.print_aplications_doc = new HashSet<print_aplications_doc>();
        }
    
        public int report_data_template_id { get; set; }
        public string report_data_template_name { get; set; }
        public string report_data_template_comment { get; set; }
        public byte[] report_data_template_xml { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<byte> Delete_statute { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<print_aplications_doc> print_aplications_doc { get; set; }
    }
}