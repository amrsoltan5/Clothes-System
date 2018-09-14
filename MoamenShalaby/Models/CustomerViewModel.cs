using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoamenShalaby.Models
{
    public class CustomerViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public DateTime date { get; set; }

    }
}