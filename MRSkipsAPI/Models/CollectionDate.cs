using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CollectionDate
    {
        public int CollectionDateId { get; set; }
 
        public DateTime Colection_Date { get; set; }

        public int NumOfSkips { get; set; }


        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}