using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.ViewModels
{
    public class FuelVM
    {
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public string token { get; set; }
        public string unit { get; set; }
        public string ReciptDate { get; set; }
        public string ReciptNo { get; set; }
        public int FuelProviderId { get; set; }
    }
}

