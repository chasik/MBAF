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
    
    public partial class credit_note_reported
    {
        public int credit_note_reported_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> report_id { get; set; }
        public Nullable<int> credit_note_id { get; set; }
        public Nullable<int> invoiced { get; set; }
        public Nullable<int> original_pack { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<int> Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    }
}
