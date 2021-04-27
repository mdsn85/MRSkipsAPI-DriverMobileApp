using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Tally
    {
        public int TallyId { get; set; }//si no

        public string DoNum { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string MonthYear { get; set; }
        public string DoDate { get; set; }
        public string ServiceType { get; set; }
        public int Qty { get; set; }
        public int NoOfTrip { get; set; }
        public float ServiceCharges { get; set; }
        public string SkipSize { get; set; }
        public string ContractDuration { get; set; }
        public string LpoNo { get; set; }

        public string TallyCode { get; set; }
        public string TallyName { get; set; }

        public int FixedTrips { get; set; }
        public int AdditionalTrip { get; set; }

        public double DM { get; set; }
        public double Tipping { get; set; }

 
        public string OwnerShip { get; set; }

       
        

    }
}