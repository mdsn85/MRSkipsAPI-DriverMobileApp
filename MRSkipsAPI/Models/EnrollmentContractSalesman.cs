using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class EnrollmentContractSalesman
    {

        public int EnrollmentContractSalesmanID { get; set; }
        public int ContractId { get; set; }
        public int SalesManId { get; set; }
        
        public DateTime StartDate { get; set; }
        [DisplayFormat(NullDisplayText = "Till Now")]
        public DateTime? EndDate { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual SalesMan SalesMan { get; set; }
    }
}