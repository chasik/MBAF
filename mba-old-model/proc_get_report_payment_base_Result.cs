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
    
    public partial class proc_get_report_payment_base_Result
    {
        public string ClientRefNumber { get; set; }
        public Nullable<long> RefNumber { get; set; }
        public string VariabilniSymbol { get; set; }
        public string DebtorName { get; set; }
        public Nullable<System.DateTime> DatumRegistrace { get; set; }
        public Nullable<decimal> PredanaCastka { get; set; }
        public Nullable<decimal> Preplatek { get; set; }
        public Nullable<decimal> UhrazeneUroky { get; set; }
        public Nullable<decimal> UhrazenyKapital { get; set; }
        public Nullable<System.DateTime> DatumPlatby { get; set; }
        public string ProvizniSazba { get; set; }
        public string ProvizniCastka { get; set; }
        public Nullable<int> IdUctu { get; set; }
        public Nullable<int> PocetDnuVMBA { get; set; }
        public Nullable<decimal> AktualniKapital { get; set; }
    }
}