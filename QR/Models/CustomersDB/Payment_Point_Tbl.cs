namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment_Point_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        public decimal? ActualAmount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? TotalAmount { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public int? SettlementType { get; set; }

        public int? BillNo { get; set; }

        [StringLength(100)]
        public string CheckDetails { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public int? CollectionPeriod { get; set; }

        public decimal? Penalty { get; set; }

        public decimal? Discount { get; set; }

        public decimal? SupplyExpenses { get; set; }

        public decimal? Other { get; set; }
    }
}
