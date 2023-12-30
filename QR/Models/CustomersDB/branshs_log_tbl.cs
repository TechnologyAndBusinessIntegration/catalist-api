namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class branshs_log_tbl
    {
        [Key]
        public int Recourd_Id { get; set; }

        [StringLength(50)]
        public string ReceiptNumber { get; set; }

        [StringLength(5)]
        public string ReceiptType { get; set; }

        [StringLength(50)]
        public string transferDate { get; set; }

        [StringLength(2000)]
        public string Response { get; set; }

        [StringLength(150)]
        public string uuid { get; set; }

        [StringLength(150)]
        public string PreviousUuid { get; set; }

        [StringLength(150)]
        public string ReferenceOldUuid { get; set; }

        public byte? sendToETA { get; set; }

        [StringLength(50)]
        public string validation { get; set; }

        [StringLength(150)]
        public string submissionUuid { get; set; }

        [StringLength(50)]
        public string branshId { get; set; }

        public int? COMID { get; set; }

        [StringLength(50)]
        public string posserial { get; set; }

        [StringLength(150)]
        public string BranchName { get; set; }

        public DateTime? edit_date { get; set; }

        public int? ReceiptNumberAsNumber { get; set; }

        public decimal? NetAmount { get; set; }
    }
}
