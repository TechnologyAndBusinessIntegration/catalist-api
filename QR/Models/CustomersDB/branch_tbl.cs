namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class branch_tbl
    {
        [Key]
        public int RecordID { get; set; }

        public int? ComID { get; set; }

        public int? branchID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string governate { get; set; }

        [StringLength(50)]
        public string regionCity { get; set; }

        [StringLength(200)]
        public string street { get; set; }

        [StringLength(50)]
        public string buildingNumber { get; set; }

        [StringLength(50)]
        public string postalCode { get; set; }

        [StringLength(50)]
        public string floor { get; set; }

        [StringLength(50)]
        public string room { get; set; }

        [StringLength(50)]
        public string landmark { get; set; }

        [StringLength(50)]
        public string additionalInformation { get; set; }

        [StringLength(50)]
        public string mailFrom { get; set; }

        [StringLength(50)]
        public string sendrPassword { get; set; }

        [StringLength(200)]
        public string maillTo { get; set; }

        [StringLength(50)]
        public string Smtp_Server_Port { get; set; }

        [StringLength(50)]
        public string Smtp_Server_Host { get; set; }

        [StringLength(500)]
        public string databaseConnGet { get; set; }

        [StringLength(50)]
        public string ResponseTableName { get; set; }

        [StringLength(50)]
        public string ReceiptNumberColumnName { get; set; }

        [StringLength(50)]
        public string branchidcolumnName { get; set; }

        [StringLength(50)]
        public string taxpayerActivityCode { get; set; }

        public int? LaoclStoreID { get; set; }
    }
}
