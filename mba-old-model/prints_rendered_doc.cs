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
    
    public partial class prints_rendered_doc
    {
        public int prints_rendered_doc_id { get; set; }
        public int prints_id { get; set; }
        public byte[] pdf_data { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public int Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    
        public virtual prints prints { get; set; }
    }
}