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
    
    public partial class installment_breakdown
    {
        public int installment_breakdown_id { get; set; }
        public Nullable<int> installment_id { get; set; }
        public Nullable<short> payment_number { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public Nullable<decimal> payment { get; set; }
        public string description { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<int> Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    
        public virtual installment installment { get; set; }
    }
}
