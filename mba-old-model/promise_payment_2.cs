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
    
    public partial class promise_payment_2
    {
        public int promise_payment_id { get; set; }
        public int case_id { get; set; }
        public int contact_id { get; set; }
        public Nullable<decimal> promise_amount_capital { get; set; }
        public Nullable<System.DateTime> promise_date_capital { get; set; }
        public Nullable<decimal> promise_amount_capital_second { get; set; }
        public Nullable<System.DateTime> promise_date_capital_second { get; set; }
        public Nullable<decimal> promise_amount_as { get; set; }
        public Nullable<System.DateTime> promise_date_as { get; set; }
        public short promise_type_activity { get; set; }
    }
}