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
    
    public partial class case_x_department_x_user
    {
        public int case_x_department_x_user_id { get; set; }
        public Nullable<int> case_id { get; set; }
        public Nullable<byte> department_id { get; set; }
        public Nullable<int> users_id { get; set; }
        public Nullable<System.DateTime> allocated { get; set; }
        public Nullable<System.DateTime> allocated_end { get; set; }
        public Nullable<byte> statute_id { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<int> Delete_statute { get; set; }
    
        public virtual @case @case { get; set; }
    }
}
