using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoamenShalaby.Models
{
    public class TransactionViewModel
    {

        public int id { get; set; }

        public int saled_Qty { get; set; }

        public double saled_Price { get; set; }

        public int Products_id { get; set; }

        public DateTime Date { get; set; }
        public bool check { get; set; }


    }
}