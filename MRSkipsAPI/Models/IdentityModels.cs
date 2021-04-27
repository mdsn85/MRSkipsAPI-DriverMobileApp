using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MRSkipsAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool? IsEnabled { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
            public System.Data.Entity.DbSet<EnqueryStatus> EnqueryStatuses { get; set; }
        public System.Data.Entity.DbSet<CustomerGroup> CustomerGroups { get; set; }
        public System.Data.Entity.DbSet<KYC> KYCs { get; set; }
        public System.Data.Entity.DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public System.Data.Entity.DbSet<InvoiceDeliveryLocation> InvoiceDeliveryLocations { get; set; }

        public System.Data.Entity.DbSet<Product> Products { get; set; }
        public System.Data.Entity.DbSet<Category_Product> Category_Products { get; set; }
        public System.Data.Entity.DbSet<Type_Product> Type_Products { get; set; }
        public System.Data.Entity.DbSet<Unit_Product> Unit_Products { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CustomerFileType> CustomerFileTypes { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CustomerFile> CustomerFiles { get; set; }


        public System.Data.Entity.DbSet<ContractType> ContractTypes { get; set; }

        public System.Data.Entity.DbSet<Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<ContractDuration> ContractDurations { get; set; }

        public System.Data.Entity.DbSet<WasteType> WasteTypes { get; set; }

        public System.Data.Entity.DbSet<OwnerShipOfSkip> OwnerShipOfSkips { get; set; }

        public System.Data.Entity.DbSet<SkipType> SkipTypes { get; set; }

        public System.Data.Entity.DbSet<SalesMan> SalesMan { get; set; }
        public System.Data.Entity.DbSet<SalesTeam> SalesTeam { get; set; }

        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<QuotationStatusAudits> QuotationStatusAudits { get; set; }
        public System.Data.Entity.DbSet<QuotationStatusAudit1> QuotationStatusAudit1s { get; set; }
        public System.Data.Entity.DbSet<KYCCode> KYCCodes { get; set; }

        public System.Data.Entity.DbSet<CustomerCode> CustomerCodes { get;set;}

        public System.Data.Entity.DbSet<EnrollmentContractSalesman> EnrollmentContractSalesmans { get; set; }

        public System.Data.Entity.DbSet<PaymentTerm> PaymentTerms { get; set; }

        public System.Data.Entity.DbSet<ContractCondition> ContractConditions { get; set; }

        public System.Data.Entity.DbSet<ContractConditionMc> ContractConditionMc { get; set; }
        public System.Data.Entity.DbSet<ContractConditionMM> ContractConditionMM { get; set; }
        public System.Data.Entity.DbSet<ContractConditionTc> ContractConditionTc { get; set; }
        public System.Data.Entity.DbSet<ContractConditionTm> ContractConditionTm { get; set; }
        public System.Data.Entity.DbSet<ContractConditionYC> ContractConditionYC { get; set; }
        public System.Data.Entity.DbSet<ContractConditionYm> ContractConditionYm { get; set; }


        public System.Data.Entity.DbSet<quotConditionTc> quotConditionTcs { get; set; }
        public System.Data.Entity.DbSet<quotConditionTm> quotConditionTms { get; set; }

        public System.Data.Entity.DbSet<LpoType> LpoTypes { get; set; }
        public System.Data.Entity.DbSet<LpoStatus> LpoStatuses { get; set; }
        public System.Data.Entity.DbSet<LPO> LPOs { get; set; }
        public System.Data.Entity.DbSet<LpoSuspend> lpoSuspends { get; set; }


        public System.Data.Entity.DbSet<Employee> employees { get; set; }

        public System.Data.Entity.DbSet<CustomerFolderHandling> CustomerFolderHandlings { get; set; }

        public System.Data.Entity.DbSet<Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CustomerSalesCategory> CustomerSalesCategories { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ContractStatus> ContractStatus { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Route> Routes { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Driver> Drivers { get; set; }

        ////public System.Data.Entity.DbSet<MRSkipsAPI.Models.Schedule> Schedules { get; set; }


        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CollectionDate> CollectionDates { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CollectionDay> CollectionDays { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CallBased> CallBaseds { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.DoSheet> DoSheets { get; set; }


        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Schedule1> Schedule1 { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TripSheet> TripSheets { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TripSheetDaetails> TripSheetDaetails { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ServiceType>  ServiceTypes { get; set; }
       public System.Data.Entity.DbSet<MRSkipsAPI.Models.ContractServiceStatus> ContractServiceStatuses { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CustomerCaller> CustomerCallers { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CollectionCanceledDate> CollectionCanceledDates { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ContractSkip> ContractSkips { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ReceiptFile> ReceiptFiles { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.SecurityDeposit> SecurityDeposits { get; set; }


        public System.Data.Entity.DbSet<MRSkipsAPI.Models.AnnualPaymentTerm> AnnualPaymentTerms { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.SkipType1> SkipType1s { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CollectionFrequency> CollectionFrequencies { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TruckType> TruckTypes { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.NatureOfBusiness> NatureOfBusinesses { get; set; }



        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Enquery> Enqueries { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ContractFile> ContractFiles { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.KycFile> KycFiles { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Lpofile> Lpofiles { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Area> Areas { get; set; }


        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Quotation> Quotations { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.QuotationFile> QuotationFiles { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.QuotationStatus> QuotationStatuses { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.QuotationType> QuotationTypes { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.QuotationValidity> QuotationValidities { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TripSheetDeatails_skip> TripSheetDeatails_skips { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Helper> Helpers { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.ActualDuty> ActualDuties { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CollectionDayMonthly> CollectionDayMonthlys { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.VehicleCheckList> VehicleCheckLists { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Shift> Shifts { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.FuelRecipt> FuelRecipt { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TermsAndCondition> TermsAndConditions { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TermsAndConditionQuta> TermsAndConditionQutas { get; set; }


        public System.Data.Entity.DbSet<MRSkipsAPI.Models.EmailServer> EmailServers { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.EmployeeUser> EmployeeUsers { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Permission> Permisssions { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.RequestApproval> RequestApprovals { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.RequestApprovalType> RequestApprovalTypes { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.PermissionUser> PermissionUsers { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.RecycleSource> RecycleSources { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.RecycleType> RecycleType { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CustomerCancelation> CustomerCancelations { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.YearlyCustCond> YearlyCustConds { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.CdcReceipt> CdcReceipts { get; set; }
        public System.Data.Entity.DbSet<MRSkipsAPI.Models.FuelProvider> FuelProviders { get; set; }

        public DbSet<ShiftHelperLink> ShiftHelperLink { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<KYC>()
                .HasOptional<ModeOfPayment>(u => u.ModeOfPayments)
                .WithOptionalPrincipal();

            //modelBuilder.Entity<Contract>()
            //   .HasOptional(s => s.Schedule) // Mark Address property optional in Student entity
            //   .WithRequired(ad => ad.Contract); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<Contract>()
              .HasOptional(s => s.Schedule1) // Mark Address property optional in Student entity
              .WithRequired(ad => ad.Contract); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            //rout helper many to many
            modelBuilder.Entity<Contract>()
             .HasMany(c => c.RecycleSources).WithMany(i => i.Contracts)
             .Map(t => t.MapLeftKey("ContractId")
                 .MapRightKey("RecycleSourceId")
            .ToTable("ContractRecycleSource"));

            //rout helper many to many
            modelBuilder.Entity<Contract>()
             .HasMany(c => c.RecycleTypes).WithMany(i => i.Contracts)
             .Map(t => t.MapLeftKey("ContractId")
                 .MapRightKey("RecycleTypeId")
            .ToTable("ContractRecycleType"));


            modelBuilder.Entity<Enquery>()
             .HasMany(c => c.RecycleSources).WithMany(i => i.Enqueries)
             .Map(t => t.MapLeftKey("EnqueryId")
                 .MapRightKey("RecycleSourceId")
            .ToTable("EnqueryRecycleSource"));

            modelBuilder.Entity<Enquery>()
             .HasMany(c => c.RecycleTypes).WithMany(i => i.Enqueries)
             .Map(t => t.MapLeftKey("EnqueryId")
                 .MapRightKey("RecycleTypeId")
            .ToTable("EnqueryRecycleType"));


            //rout helper many to many
            modelBuilder.Entity<Route>()
             .HasMany(c => c.Helper).WithMany(i => i.Route)
             .Map(t => t.MapLeftKey("RouteId")
                 .MapRightKey("HelperId")
            .ToTable("RouteHelper"));

            modelBuilder.Entity<TripSheetDaetails>()
                 .HasMany(c => c.Helper).WithMany(i => i.TripSheetDaetails)
                 .Map(t => t.MapLeftKey("TripSheetDaetailsId")
                     .MapRightKey("HelperId")
                .ToTable("TripSheetDaetailHelper"));



            modelBuilder.Entity<ActualDuty>()
                 .HasMany(c => c.Helper).WithMany(i => i.ActualDuty)
                 .Map(t => t.MapLeftKey("ActualDutyId")
                     .MapRightKey("HelperId")
                .ToTable("ActualDutyHelper"));

            modelBuilder.Entity<TripSheet>()
             .HasMany(c => c.Helper).WithMany(i => i.TripSheet)
             .Map(t => t.MapLeftKey("TripSheetId")
                 .MapRightKey("HelperId")
            .ToTable("TripSheetHelper"));


            modelBuilder.Entity<ShiftHelperLink>()
            .HasKey(x => new { x.ShiftId, x.HelperId });

            modelBuilder.Entity<ShiftHelperLink>()
            .HasRequired(pt => pt.Shift)
            .WithMany(p => p.ShiftHelperLinks)
            .HasForeignKey(pt => pt.ShiftId);

            modelBuilder.Entity<ShiftHelperLink>()
                .HasRequired(pt => pt.Helper)
                .WithMany(t => t.ShiftHelperLinks)
                .HasForeignKey(pt => pt.HelperId);

            //modelBuilder.Entity<Customer>()
            //.HasOptional(s => s.CustomerCallers)
            //.WithMany()
            //.WillCascadeOnDelete(false);

            ////rout helper many to many
            //modelBuilder.Entity<Contract>()
            // .HasMany(c => c.ContractConditions).WithMany(i => i.Contract)
            // .Map(t => t.MapLeftKey("ContractId")
            //     .MapRightKey("ContractConditionId")
            //.ToTable("ConditionsOfContracts"));



            //        modelBuilder.Entity<Contract>()
            //        .HasOptional(x => x.Schedule)
            //.WithOptionalDependent(l => l.Contract);

            //        modelBuilder.Entity<Schedule>()
            //                    .HasKey(x => x.ContractId);
            //        modelBuilder.Entity<Schedule>()
            //        .Property(x => x.ContractId)
            //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //            modelBuilder.Entity<Schedule>()
            //.HasRequired(lu => lu.Contract)
            //.WithOptional(pi => pi.Schedule);



            modelBuilder.Entity<EnqueryProduct>().HasKey(p => new { p.EnqueryId, p.ProductId });
            modelBuilder.Entity<Enquery>().HasMany(p => p.EnqueryProducts).WithRequired().HasForeignKey(p => p.EnqueryId);
            modelBuilder.Entity<Product>().HasMany(p => p.EnqueryProducts).WithRequired().HasForeignKey(p => p.ProductId);

        }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.LocationMaster> LocationMasters { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.DumpLocation> DumpLocations { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Competitor> Competitors { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.EnqueryProduct> EnqueryProducts { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Dumb> Dumbs { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.VehicleMaker> VehicleMakers { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.TripsSigner> TripsSigners { get; set; }

        public System.Data.Entity.DbSet<MRSkipsAPI.Models.Tally> Tally { get; set; }
        // public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.SalesReport> SalesReports { get; set; }





        //  public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.totalTripByhelper> totalTripByhelpers { get; set; }



        // public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.ExpiredNoAction> ExpiredNoActions { get; set; }

        //  public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.ExpiredNoAction> ExpiredNoActions { get; set; }

        //public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.AuditSalesWorkflow> AuditSalesWorkflows { get; set; }

        //  public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.SecurityDepositReport> SecurityDepositReports { get; set; }

        //   public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.CustomerNeedToCancel> CustomerNeedToCancels { get; set; }



        //public System.Data.Entity.DbSet<MRSkipsAPI.ModelsReport.ReportSalesInvoiceUploader> ReportSalesInvoiceUploaders { get; set; }


        // public System.Data.Entity.DbSet<MRSkipsAPI.Models.ReportSuspendedClients> ReportSuspendedClients { get; set; }
    }
}