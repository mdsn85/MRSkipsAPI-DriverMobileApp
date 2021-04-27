using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CollectionDayMonthly
    {
        public int CollectionDayMonthlyId { get; set; }

        public int DayOfMonth { get; set; }


        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}