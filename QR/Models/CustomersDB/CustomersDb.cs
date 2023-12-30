using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QR.Models.CustomersDB
{
    public partial class CustomersDb : DbContext
    {
        public CustomersDb()
            : base("name=CustomersDb")
        {
        }

        public virtual DbSet<branch_tbl> branch_tbl { get; set; }
        public virtual DbSet<branshs_log_tbl> branshs_log_tbl { get; set; }
        public virtual DbSet<Category_Tbl> Category_Tbl { get; set; }
        public virtual DbSet<Com_Tbl> Com_Tbl { get; set; }
        public virtual DbSet<Currency_Tbl> Currency_Tbl { get; set; }
        public virtual DbSet<Cus_Tbl> Cus_Tbl { get; set; }
        public virtual DbSet<Department_Tbl> Department_Tbl { get; set; }
        public virtual DbSet<ETA_document_Tbl> ETA_document_Tbl { get; set; }
        public virtual DbSet<GS1_ITEMS_TBL> GS1_ITEMS_TBL { get; set; }
        public virtual DbSet<Integrate_setup_tbl_New> Integrate_setup_tbl_New { get; set; }
        public virtual DbSet<invalid_usingUrl_log_tbl> invalid_usingUrl_log_tbl { get; set; }
        public virtual DbSet<Items_Tbl> Items_Tbl { get; set; }
        public virtual DbSet<LicenseTbl> LicenseTbls { get; set; }
        public virtual DbSet<MainCom_Tbl> MainCom_Tbl { get; set; }
        public virtual DbSet<Measurement_Units_Tbl> Measurement_Units_Tbl { get; set; }
        public virtual DbSet<MyContact_tbl> MyContact_tbl { get; set; }
        public virtual DbSet<Names_Translation_Tbl> Names_Translation_Tbl { get; set; }
        public virtual DbSet<Payment_Point_Tbl> Payment_Point_Tbl { get; set; }
        public virtual DbSet<PosMachin_tbl> PosMachin_tbl { get; set; }
        public virtual DbSet<Registeration_Request_Tbl> Registeration_Request_Tbl { get; set; }
        public virtual DbSet<RunningLog_tbl> RunningLog_tbl { get; set; }
        public virtual DbSet<Sales_Tbl> Sales_Tbl { get; set; }
        public virtual DbSet<Scopos_error_log_tbl> Scopos_error_log_tbl { get; set; }
        public virtual DbSet<TblAssignComp> TblAssignComps { get; set; }
        public virtual DbSet<TblAssignFunction> TblAssignFunctions { get; set; }
        public virtual DbSet<TblAssignGroup> TblAssignGroups { get; set; }
        public virtual DbSet<TblAttachedFile> TblAttachedFiles { get; set; }
        public virtual DbSet<TblDeal> TblDeals { get; set; }
        public virtual DbSet<TblError> TblErrors { get; set; }
        public virtual DbSet<TblFunction> TblFunctions { get; set; }
        public virtual DbSet<TblGroup> TblGroups { get; set; }
        public virtual DbSet<TblLoginType> TblLoginTypes { get; set; }
        public virtual DbSet<TblPasswordHistory> TblPasswordHistories { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<zPOSRegistrationRequest> zPOSRegistrationRequests { get; set; }
        public virtual DbSet<AssignCus_V> AssignCus_V { get; set; }
        public virtual DbSet<AssignFunctions_V> AssignFunctions_V { get; set; }
        public virtual DbSet<AssignGroups_V> AssignGroups_V { get; set; }
        public virtual DbSet<AssignSales_V> AssignSales_V { get; set; }
        public virtual DbSet<COM_INFO_ETA_Report_V> COM_INFO_ETA_Report_V { get; set; }
        public virtual DbSet<COM_INFO_Inv_WS_V> COM_INFO_Inv_WS_V { get; set; }
        public virtual DbSet<COM_INFO_V> COM_INFO_V { get; set; }
        public virtual DbSet<Registration_Request_V> Registration_Request_V { get; set; }
        public virtual DbSet<V_Users> V_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<branch_tbl>()
                .Property(e => e.maillTo)
                .IsUnicode(false);

            modelBuilder.Entity<branshs_log_tbl>()
                .Property(e => e.NetAmount)
                .HasPrecision(10, 5);

            modelBuilder.Entity<Com_Tbl>()
                .Property(e => e.ArrangeWorkTimes)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Currency_Tbl>()
                .Property(e => e.currencyExchangeRate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.ActualAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.TotalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.Penalty)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.Discount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.SupplyExpenses)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment_Point_Tbl>()
                .Property(e => e.Other)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TblDeal>()
                .Property(e => e.OVD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TblDeal>()
                .Property(e => e.DEAL_AMOUNT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TblDeal>()
                .Property(e => e.DEPOSIT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TblDeal>()
                .Property(e => e.NEW_EMI)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TblDeal>()
                .Property(e => e.WAIVED_AMOUNT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.BuydownPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.CommissionAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.CommissionMaximum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.PriceA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.PriceB)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.PriceC)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.SalePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.PriceLowerBound)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.PriceUpperBound)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.DBTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<item>()
                .Property(e => e.LastCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.ReplacementCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<item>()
                .Property(e => e.MSRP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.EnvironmentStatues)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.SendWayName)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.ItemFlagName)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.PriceFlagName)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.DBGetTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.DBSetTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<COM_INFO_V>()
                .Property(e => e.maillTo)
                .IsUnicode(false);

            modelBuilder.Entity<Registration_Request_V>()
                .Property(e => e.RequestStatues)
                .IsUnicode(false);
        }
    }
}
