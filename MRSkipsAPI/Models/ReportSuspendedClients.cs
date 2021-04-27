using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MRSkipsAPI.Models
{
    public class ReportSuspendedClients
    {
        public int ReportSuspendedClientsid { get; set; }
        public String CustomerCode { get; set; }

        public String CustomerName { get; set; }
        public DateTime SuspensionDate { get; set; }

        public String Location { get; set; }
        public String Size { get; set; }
        public int SkipsNo { get; set; }
        public float MinTrips { get; set; }


        }

}