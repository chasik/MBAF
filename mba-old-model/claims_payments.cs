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
    
    public partial class claims_payments
    {
        public int id_claims_payment { get; set; }
        public int case_id { get; set; }
        public int claims_payment_state_id { get; set; }
        public int payment_problem_id { get; set; }
        public string description_mba { get; set; }
        public int claims_payment_solution_id { get; set; }
        public string description_client { get; set; }
        public byte[] payment_document { get; set; }
        public System.Guid url_parametr_sec1 { get; set; }
        public System.Guid url_parametr_sec2 { get; set; }
        public System.Guid url_parametr_sec3 { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public int Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public Nullable<System.DateTime> claims_payment_insert { get; set; }
        public Nullable<System.DateTime> insert_document { get; set; }
        public Nullable<System.DateTime> send_to_client { get; set; }
        public Nullable<System.DateTime> return_from_client { get; set; }
        public Nullable<System.DateTime> claims_payment_close { get; set; }
        public int task_id { get; set; }
    
        public virtual @case @case { get; set; }
        public virtual task task { get; set; }
    }
}