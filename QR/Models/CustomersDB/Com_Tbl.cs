namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Com_Tbl
    {
        public int? id { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        public int? branchID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string governate { get; set; }

        [StringLength(50)]
        public string regionCity { get; set; }

        [StringLength(50)]
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
        public string taxpayerActivityCode { get; set; }

        [Key]
        public int Recourd_ID { get; set; }

        public bool? RunType { get; set; }

        public decimal? ArrangeWorkTimes { get; set; }

        public DateTime? NextRunTime { get; set; }

        public bool? RunStutes { get; set; }

        [StringLength(100)]
        public string ClientId { get; set; }

        [StringLength(150)]
        public string editor { get; set; }

        [StringLength(500)]
        public string dashboardConnGet { get; set; }

        [StringLength(10)]
        public string TypeVersion { get; set; }

        public int? SendToEtaWay { get; set; }

        public int? ItemFlag { get; set; }

        public int? PriceFlag { get; set; }

        [StringLength(50)]
        public string DashboardResponseTable { get; set; }

        public int? MainComID { get; set; }

        public byte? SendToEtaRequestType { get; set; }

        public int? TokenValidation { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(500)]
        public string ETA_Invoice_Report_CONN { get; set; }
    }
}
