using MRSkipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
     public class ApplicationDbContext : DbContext
     {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CustomerGroup> CustomerGroups { get; set; }
        public System.Data.Entity.DbSet<KYC> KYCs { get; set; }
        public System.Data.Entity.DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public System.Data.Entity.DbSet<InvoiceDeliveryLocation> InvoiceDeliveryLocations { get; set; }

        public System.Data.Entity.DbSet<Product> Products { get; set; }
        public System.Data.Entity.DbSet<Category_Product> Category_Products { get; set; }
        public System.Data.Entity.DbSet<Type_Product> Type_Products { get; set; }
        public System.Data.Entity.DbSet<Unit_Product> Unit_Products { get; set; }

        public System.Data.Entity.DbSet<CustomerFileType> CustomerFileTypes { get; set; }

        public System.Data.Entity.DbSet<CustomerFile> CustomerFiles { get; set; }


        public System.Data.Entity.DbSet<ContractType> ContractTypes { get; set; }

        public System.Data.Entity.DbSet<Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<ContractDuration> ContractDurations { get; set; }

        public System.Data.Entity.DbSet<WasteType> WasteTypes { get; set; }

        public System.Data.Entity.DbSet<OwnerShipOfSkip> OwnerShipOfSkips { get; set; }

        public System.Data.Entity.DbSet<SkipType> SkipTypes { get; set; }

        public System.Data.Entity.DbSet<SalesMan> SalesMan { get; set; }

        public System.Data.Entity.DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<KYCCode> KYCCodes { get; set; }

        public System.Data.Entity.DbSet<CustomerCode> CustomerCodes { get;set;}

        public System.Data.Entity.DbSet<EnrollmentContractSalesman> EnrollmentContractSalesmans { get; set; }

        public System.Data.Entity.DbSet<PaymentTerm> PaymentTerms { get; set; }

        public System.Data.Entity.DbSet<ContractCondition> ContractConditions { get; set; }

        public System.Data.Entity.DbSet<LpoType> LpoTypes { get; set; }
        public System.Data.Entity.DbSet<LpoStatus> LpoStatuses { get; set; }
        public System.Data.Entity.DbSet<LPO> LPOs { get; set; }
        public System.Data.Entity.DbSet<LpoSuspend> lpoSuspends { get; set; }


        public System.Data.Entity.DbSet<Employee> employees { get; set; }

        public System.Data.Entity.DbSet<CustomerFolderHandling> CustomerFolderHandlings { get; set; }

        public System.Data.Entity.DbSet<Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<CustomerSalesCategory> CustomerSalesCategories { get; set; }

        public System.Data.Entity.DbSet<ContractStatus> ContractStatus { get; set; }

        public System.Data.Entity.DbSet<Route> Routes { get; set; }

        public System.Data.Entity.DbSet<Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<Schedule> Schedules { get; set; }


        public System.Data.Entity.DbSet<CollectionDate> CollectionDates { get; set; }

        public System.Data.Entity.DbSet<CollectionDay> CollectionDays { get; set; }

        public System.Data.Entity.DbSet<CallBased> CallBaseds { get; set; }

        public System.Data.Entity.DbSet<DoSheet> DoSheets { get; set; }


        public System.Data.Entity.DbSet<Schedule1> Schedule1 { get; set; }

        public System.Data.Entity.DbSet<TripSheet> TripSheets { get; set; }
        public System.Data.Entity.DbSet<TripSheetDaetails> TripSheetDaetails { get; set; }
        public System.Data.Entity.DbSet<ServiceType>  ServiceTypes { get; set; }
       public System.Data.Entity.DbSet<ContractServiceStatus> ContractServiceStatuses { get; set; }
        public System.Data.Entity.DbSet<CustomerCaller> CustomerCallers { get; set; }

        public System.Data.Entity.DbSet<CollectionCanceledDate> CollectionCanceledDates { get; set; }

        public System.Data.Entity.DbSet<ContractSkip> ContractSkips { get; set; }

        public System.Data.Entity.DbSet<ReceiptFile> ReceiptFiles { get; set; }
        public System.Data.Entity.DbSet<SecurityDeposit> SecurityDeposits { get; set; }


        public System.Data.Entity.DbSet<AnnualPaymentTerm> AnnualPaymentTerms { get; set; }

        public System.Data.Entity.DbSet<SkipType1> SkipType1s { get; set; }
        public System.Data.Entity.DbSet<CollectionFrequency> CollectionFrequencies { get; set; }
        public System.Data.Entity.DbSet<TruckType> TruckTypes { get; set; }

        public System.Data.Entity.DbSet<NatureOfBusiness> NatureOfBusinesses { get; set; }



        public System.Data.Entity.DbSet<Enquery> Enqueries { get; set; }
        public System.Data.Entity.DbSet<ContractFile> ContractFiles { get; set; }
        public System.Data.Entity.DbSet<KycFile> KycFiles { get; set; }

        public System.Data.Entity.DbSet<Lpofile> Lpofiles { get; set; }
        public System.Data.Entity.DbSet<ActualDuty> ActualDuties { get; set; }
        public System.Data.Entity.DbSet<Shift> Shifts { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<KYC>()
                .HasOptional<ModeOfPayment>(u => u.ModeOfPayments)
                .WithOptionalPrincipal();

            modelBuilder.Entity<Contract>()
               .HasOptional(s => s.Schedule) // Mark Address property optional in Student entity
               .WithRequired(ad => ad.Contract); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<Contract>()
              .HasOptional(s => s.Schedule1) // Mark Address property optional in Student entity
              .WithRequired(ad => ad.Contract); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student


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

        }

    }
}