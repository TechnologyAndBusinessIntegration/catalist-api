﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QR
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Scopos_Customers_DBEntities : DbContext
    {
        public Scopos_Customers_DBEntities()
            : base("name=Scopos_Customers_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<branch_tbl> branch_tbl { get; set; }
        public virtual DbSet<branshs_log_tbl> branshs_log_tbl { get; set; }
        public virtual DbSet<Category_Tbl> Category_Tbl { get; set; }
        public virtual DbSet<Com_Tbl> Com_Tbl { get; set; }
        public virtual DbSet<Currency_Tbl> Currency_Tbl { get; set; }
        public virtual DbSet<Cus_Tbl> Cus_Tbl { get; set; }
        public virtual DbSet<dbo_Scopos_error_log_tbl> dbo_Scopos_error_log_tbl { get; set; }
        public virtual DbSet<Department_Tbl> Department_Tbl { get; set; }
        public virtual DbSet<ETA_document_Tbl> ETA_document_Tbl { get; set; }
        public virtual DbSet<Integrate_setup_tbl_New> Integrate_setup_tbl_New { get; set; }
        public virtual DbSet<LicenseTbl> LicenseTbls { get; set; }
        public virtual DbSet<Measurement_Units_Tbl> Measurement_Units_Tbl { get; set; }
        public virtual DbSet<MyContact_tbl> MyContact_tbl { get; set; }
        public virtual DbSet<Names_Translation_Tbl> Names_Translation_Tbl { get; set; }
        public virtual DbSet<Payment_Point_Tbl> Payment_Point_Tbl { get; set; }
        public virtual DbSet<PosMachin_tbl> PosMachin_tbl { get; set; }
        public virtual DbSet<Registeration_Request_Tbl> Registeration_Request_Tbl { get; set; }
        public virtual DbSet<RunningLog_tbl> RunningLog_tbl { get; set; }
        public virtual DbSet<Sales_Tbl> Sales_Tbl { get; set; }
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
    }
}
