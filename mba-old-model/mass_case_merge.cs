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
    
    public partial class mass_case_merge
    {
        public int mass_case_merge_id { get; set; }
        public int client_id { get; set; }
        public System.DateTime merge_date { get; set; }
        public long ref_number { get; set; }
        public int debtor_id { get; set; }
        public string insert_user { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public string update_user { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<System.DateTime> update_date_dbo { get; set; }
        public string delete_user { get; set; }
        public Nullable<System.DateTime> delete_date { get; set; }
        public Nullable<byte> delete_statute { get; set; }
    }
}
