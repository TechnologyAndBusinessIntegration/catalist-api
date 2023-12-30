namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PosMachin_tbl
    {
        public int? comid { get; set; }

        public int? branchID { get; set; }

        public int? POS_id { get; set; }

        public DateTime? LicenseExpiryDate { get; set; }

        [StringLength(50)]
        public string POSName { get; set; }

        [StringLength(50)]
        public string posserial { get; set; }

        [StringLength(50)]
        public string clintId { get; set; }

        [StringLength(200)]
        public string scId { get; set; }

        [StringLength(50)]
        public string pososversion { get; set; }

        public bool? status { get; set; }

        [Key]
        public int RecordID { get; set; }

        public byte? ENVIRONMENT { get; set; }

        [StringLength(200)]
        public string AndroidID { get; set; }

        public bool? licenseStatus { get; set; }

        [StringLength(300)]
        public string databaseConnGet { get; set; }

        [StringLength(300)]
        public string databaseConnSet { get; set; }

        public byte? DBSetType { get; set; }

        public byte? DBGetType { get; set; }

        public DateTime? LastRunning { get; set; }
    }
}
