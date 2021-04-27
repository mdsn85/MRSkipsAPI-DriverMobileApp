using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum LeadStatusList { Open /*when create*/, Quotation_Send /*when create Qutation*/, Out_Of_Scope, Cancelled, Success , reproach }
    public class Lead
    {
        public int LeadId { get; set; }

        [Display(Name = "Enquery Code")]
        public String Code { get; set; }

        [Display(Name = "Is New Customer")]
        public bool IsNewCustomer { get; set; }

        /// <summary>
        /// Select customer get details from customer master  (contact /salesman)
        /// </summary>
        [Display(Name = "Select Customer")]
        public int? CustomerId { get; set; } //(select from system)
        public virtual Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public String CustomerName { get; set; }
        [Display(Name = "Contact Person")]
        public String ContactPerson { get; set; }
        [Display(Name = "Mobile No")]
        public String MobileNo { get; set; }
        [Display(Name = "Telephone No")]
        public String TelephoneNo { get; set; }
        [Display(Name = "Fax No")]
        public String FaxNo { get; set; }
        [Display(Name = "Email")]
        public String EmailId { get; set; }


        [Display(Name = "How Did You Hear About Us?")]
        public String HowUCome { get; set; }

        /////////////
        [Display(Name = "Is New Location")]
        public bool IsNewLocation { get; set; }

        [Display(Name = "Enquery Status")]
        public EnqueryStatusList? EnqueryStatus { get; set; }
        public String StatusReason { get; set; }
        /// <summary>
        /// get all location from contract
        /// </summary>
        /// 
        [Display(Name = "Location")]
        public String Location { get; set; }

        [Display(Name = "Sales Person")]
        public int? SalesManId { get; set; } //(select from system)
        public virtual SalesMan SalesMan { get; set; }

        // comon
        public String Description { get; set; }

        //collect location from contract of selected customers
        public virtual ICollection<Quotation> Quotations { get; set; }


        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Who Created")]
        public String UserCreate { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Who Last Update")]
        public String UserLastUpdate { get; set; }

        [Display(Name = "Last Status Date")]
        public DateTime? LastStatusDate { get; set; }

        [Display(Name = "Who Last Change Stataus")]
        public String UserLastStatus { get; set; }
    }
}