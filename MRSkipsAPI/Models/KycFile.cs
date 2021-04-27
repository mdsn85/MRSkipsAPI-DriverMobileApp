using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class KycFile
    {


        public int KycFileId { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }


        public DateTime? ValidUntil { get; set; }

        public virtual KYC KYC { get; set; }
        public int? KYCId { get; set; }
    }
    
}