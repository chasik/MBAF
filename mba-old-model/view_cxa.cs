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
    
    public partial class view_cxa
    {
        public int CxA_id { get; set; }
        public int company_id { get; set; }
        public int address_id { get; set; }
        public string cpop { get; set; }
        public string cor { get; set; }
        public Nullable<short> Type { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<byte> Source { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public Nullable<byte> priority { get; set; }
        public string description { get; set; }
    }
}