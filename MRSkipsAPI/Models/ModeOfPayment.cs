using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ModeOfPayment
    {
        public int ModeOfPaymentId { get; set; }

        //BankTransferCheque,CashonInvoiceDelivery

        [Display(Name = "Mode Of Payment")]
        public string Name { get; set; }

        public virtual ICollection<KYC> KYC { get; set; }

    }
}