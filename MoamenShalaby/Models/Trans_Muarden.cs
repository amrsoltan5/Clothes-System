//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoamenShalaby.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trans_Muarden
    {
        public int id { get; set; }
        public Nullable<int> muarden_id { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Cash { get; set; }
        public Nullable<decimal> Reminder { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Muarden Muarden { get; set; }
    }
}
