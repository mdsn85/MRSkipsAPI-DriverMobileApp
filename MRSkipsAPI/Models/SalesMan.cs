using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class SalesMan
    {
        public int SalesManId { get; set; }

        [Display(Name = "Sales Person")]
        public string Name { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "App Username")]
        public String AppUserName { get; set; }
        public String AppPassWard { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }


        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<KYC> KYCs { get; set; }
        public virtual ICollection<Enquery> Enqueries { get; set; }

       // public virtual ICollection<SalesMan> SalesMans { get; set; }

        public virtual ICollection<EnrollmentContractSalesman> EnrollmentContractSalesmans { get; set; }



        //team he is belong to 
        [Display(Name = "Sales Team")]
        public int? SalesTeamId { get; set; }
        public virtual SalesTeam SalesTeams { get; set; }

        [Display(Name = "Is Team Leader")]
        public bool isTeamleader { get; set; }



    }
}