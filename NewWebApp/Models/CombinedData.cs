using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWebApp.Models
{
    public class CombinedData
    {
        public decimal AggregateMSQ { get; set; }
        public decimal Smp { get; set; }
        public string DeliveryTime { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string TradeDate { get; set; }

    }
}