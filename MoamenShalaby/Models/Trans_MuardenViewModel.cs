using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoamenShalaby.Models
{
    public class Trans_MuardenViewModel
    {
        public int id { get; set; }
        public int muarden_id { get; set; }
        public decimal Total { get; set; }
        public decimal Cash { get; set; }
        public decimal Reminder { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}