using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum DepositResult { Adjust, Refund, InComeAccount,No_Deposit};
    public enum PaymentFeedBack1Types { Good, Bad, Case, Doubtful_Debt, Bad_Debt };
    public class CustomerCancelation
    {
        public int CustomerCancelationId { get; set; }

        [Display(Name = "All Skips Pullout ")]
        public bool AllSkipsPullout { get; set; }

        [Display(Name = "Deposit ")]
        public DepositResult Deposit { get; set; }


        [Display (Name = "Final Invoice")]
        public bool FinalInvoie { get; set; }

        [Display(Name = "OutStand Clearnce")]
        public bool OutStandClearnce { get; set; }


        [Display(Name = "Payment FeedBack ")]
        public PaymentFeedBack1Types PaymentFeedBack { get; set; }


        [Display(Name = "Shred It")]
        public bool Shred { get; set; }

        public string Comment  { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}