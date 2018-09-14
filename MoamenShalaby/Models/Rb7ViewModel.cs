using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoamenShalaby.Models
{
    public class Rb7ViewModel
    {
        public int id { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public decimal Price_Total { get; set; }
        public decimal Qty_Total_Saled { get; set; }
        public decimal rb7 { get; set; }

    }
}