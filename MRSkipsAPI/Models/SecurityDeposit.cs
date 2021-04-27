using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class SecurityDeposit
    {
        public enum ModeOfPaymentList { Cash, Dated_Chq, Undated_Chq}

        public int SecurityDepositId { get; set; }


        [Display(Name = "Security Deposit")]
        public double SecurityDepositAmount { get; set; }

        [Display(Name = "Skip Deposit")]
        public double SkipDeposit { get; set; }

        [Display(Name = "Tipping Fee Deposit ")]
        public double TippingFeeDeposit { get; set; }

        [Display(Name = "Amount Paid")]
        public double AmountPaid { get; set; }

        [Display(Name = "Mode Of Payment Name")]
        public ModeOfPaymentList ModeOfPaymentName { get; set; }



        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Chq Date")]
        public DateTime? ChqDate { get; set; }

        [Display(Name = "Chq Amount")]
        public double? ChqAmount { get; set; }

        [Display(Name = "Chq No")]
        public string ChqNo { get; set; }

        [Display(Name = "Receipt No")]
        public string  ReceiptNo { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Receipt Date")]
        public DateTime ReceiptDate { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public int? ReceiptFileId { get; set; }
        public virtual ReceiptFile ReceiptFile{ get; set; }
    }
}