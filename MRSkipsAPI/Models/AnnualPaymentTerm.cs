using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{


    public enum ModeOfPaymentListTerm { Cash, Dated_Chq, Undated_Chq }
    public class AnnualPaymentTerm
    {
        public int AnnualPaymentTermId { get; set; }

        [Display(Name = "Amount Paid")]
        public double AmountPaid { get; set; }

        [Display(Name = "Mode Of Payment Name")]
        public ModeOfPaymentListTerm ModeOfPaymentName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Payment")]
        public DateTime DateOfPayment { get; set; }

        [Display(Name = "Balance")]
        public double Balance { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}