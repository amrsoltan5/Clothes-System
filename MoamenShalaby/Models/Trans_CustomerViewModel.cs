using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoamenShalaby.Models
{
    public class Trans_CustomerViewModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public decimal total { get; set; }
        public decimal cash { get; set; }
        public decimal reminder { get; set; }
        public string notes { get; set; }
        public DateTime date { get; set; }

    }
}