using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Code { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Email Signature")]
        public string EmailSignature { get; set; }

        //[Display(Name = "Job")]
        //public int? JobId { get; set; }
        //public virtual Job Job { get; set; }

        public virtual ICollection<CustomerFolderHandling> CustomerFolderHandlings { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }

        public virtual ICollection<SalesMan> SalesMen { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<SalesTeam> SalesTeams { get; set; }
    }
}