using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CdcReceipt
    {
        public int CdcReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public float ServiceCharges { get; set; }
        public float AmountCollected { get; set; }

        public int DriverId { get; set; }
        public virtual Driver Drivers { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}


//public float ServiceCharges { get; set; }
//public int SkipNo { get; set; }

//public float Amount { get; set; }//ServiceCharges x SkipNo