using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class KYC
    {
        public int KYCId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }

        [Display(Name = "Sales Person")]
        public int SalesManId { get; set; }
        public virtual SalesMan SalesMan { get; set; }
         
        [Display(Name = "KYC Code")]
        public string KYCCode { get; set; }


        [Display(Name = "Owner's Name")]
        public string OwnerName { get; set; }
        [Display(Name = "Owner's Contact")]
        public string OwnerContact { get; set; }
        [Display(Name = "Owner's Email")]
        public string OwnerEmail { get; set; }

        [Display(Name = "MD's Name")]
        public string MdName { get; set; }
        [Display(Name = "MD's Contact")]
        public string MdContact { get; set; }
        [Display(Name = "MD's Email")]
        public string MdEmail { get; set; }


        [Display(Name = "Client Supplier Ref. Contact 1")]
        public string ClientSupplier1 { get; set; }
        [Display(Name = "Client Supplier Ref. Contact 2")]
        public string ClientSupplier2 { get; set; }

        //ContactDetails(Office)
        [Display(Name = "Contact Office Name")]
        public string ContactOfficeName { get; set; }
        [Display(Name = "Designation")]
        public string ContactOfficeDesignation { get; set; }
        [Display(Name = "Department")]
        public string ContactOfficeDepartment { get; set; }
        [Display(Name = "Mobile No")]
        public string ContactOfficeMobileNo { get; set; }
        [Display(Name = "Tel No/Extn")]
        public string ContactOfficeTelNoExtn { get; set; }
        [Display(Name = "Fax No")]
        public string ContactOfficeFax { get; set; }
        [EmailAddress]
        [Display(Name = "Email ")]
        public string ContactOfficeEmail { get; set; }
        [Display(Name = "Remarks")]
        public string ContactOfficeRemarks { get; set; }

        //AccountsDetails INVOICEDELIVERYINFORMATION


        [Display(Name = "Cut-off date of invoice submission")]
        public string CutOffdateofinvoicesubmission { get; set; }
        [Display(Name = "Invoice Delivery/Email")]
        public bool InvoiceDeliveryThroughEmail { get; set; }
        [Display(Name = "Invoice Delivery/Hardcopy")]
        public bool InvoiceDeliveryHardcopy { get; set; }


        [Display(Name = "Invoice Delivery Location")]
        public int? InvoiceDeliveryLocationId { get; set; }
        public virtual InvoiceDeliveryLocation InvoiceDeliveryLocations { get; set; }



        [Display(Name = "Invoice Delivery Address")]
        public string InvoiceDeliveryAddress { get; set; }


        [Display(Name = "Makani No.")]
        public string MakaniNo { get; set; }


        [Display(Name = "Contact Person (Name & Designation) ")]
        public string InvoiceAccountContactPerson { get; set; }
        [Display(Name = "Invoice Account Contact No ")]
        public string InvoiceAccountContactNo { get; set; }
        [EmailAddress]
        [Display(Name = "Invoice Account Email ")]
        public string InvoiceAccountEmail { get; set; }

        //PAYMENTFOLLOWUPDETAILS

        [Display(Name = "Mode of Payment")]
        public int? ModeOfPaymentId { get; set; }
        public virtual ModeOfPayment ModeOfPayments { get; set; }

        [Display(Name = "Accounts Payable")]
        public string PaymentAccountsPayable { get; set; }
        [Display(Name = "Mobile No")]
        public string PaymentAccountMobileNo { get; set; }
        [Display(Name = "Tel No/Extn")]
        public string PaymentAccountTelNoExtn { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string PaymentAccountEmail { get; set; }

        [Display(Name = "Finance Manger Name ")]
        public string FinanceMangerName { get; set; }
        [Display(Name = "Contact No")]
        public string FinanceMangerContactNo { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string FinanceMangerEmail { get; set; }

        public string PaymentCollectionDetails { get; set; }
        [Display(Name = "Payment Collection Location")]
        public string CollectionLocation { get; set; }
        [Display(Name = "Contact Person")]
        public string CollectionContactPerson { get; set; }
        [Display(Name = "Person Designation")]
        public string CollectionContactPersonDesignation { get; set; }
        [Display(Name = "Contact No")]
        public string CollectionContactNo { get; set; }
        [Display(Name = "Preferred Collection Days")]
        public string PaymentCollectionDays { get; set; }
        [Display(Name = "Preferred Collection Timing")]
        public string PaymentCollectionTiming { get; set; }
        [Display(Name = "Remarks")]
        public string CollectionPaymentRemarks { get; set; }

        //SiteDetails
        [Required]
        [Display(Name = "Site Location")]
        public string SiteLocation { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        
        [Display(Name = "Contact Person Name (Day Shift)")]
        public string SiteContactPersonNameDayShift { get; set; }
        [Display(Name = "Designation")]
        public string SiteDayDesignation { get; set; }
        [EmailAddress]
        [Display(Name = "Site Day Email")]
        public string SiteDayEmail { get; set; }
        [Display(Name = "Mobile No")]
        public string SiteDayMobileNo { get; set; }
        [Display(Name = "Contact Person Name (Night Shift)")]
        public string SiteContactPersonNameNightShift { get; set; }
        [Display(Name = "Designation")]
        public string SiteNightDesignation { get; set; }
        [EmailAddress]
        [Display(Name = "Site Night Email")]
        public string SiteNightEmail { get; set; }
        [Display(Name = "Mobile No")]
        public string SiteNightMobileNo { get; set; }
        [Display(Name = "Remarks")]
        public string SiteNightRemarks { get; set; }
        public int? DocumentId { get; set; }
        public DateTime CreatedIn { get; set; }

   

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<CustomerFile> ClientsFiles { get; set; }

        public virtual ICollection<KycFile> KycFiles { get; set; }



        [Display(Name = "Who Created")]
        public String UserCreate { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Who Last Update")]
        public String UserLastUpdate { get; set; }
    }
}