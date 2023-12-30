namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COM_INFO_V
    {
        public byte? SendToEtaRequestType { get; set; }

        public int? Maincomid { get; set; }

        [StringLength(200)]
        public string MainComName { get; set; }

        public int? RecordID { get; set; }

        [StringLength(50)]
        public string branchidcolumnName { get; set; }

        [StringLength(50)]
        public string ResponseTableName { get; set; }

        [StringLength(50)]
        public string ReceiptNumberColumnName { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int comid { get; set; }

        public int? branchID { get; set; }

        public int? POS_id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public int? tax_id { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [StringLength(50)]
        public string taxpayerActivityCode { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

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

        public byte? ENVIRONMENT { get; set; }

        [StringLength(200)]
        public string AndroidID { get; set; }

        [StringLength(10)]
        public string EnvironmentStatues { get; set; }

        [StringLength(500)]
        public string dashboardConnGet { get; set; }

        [StringLength(10)]
        public string TypeVersion { get; set; }

        public int? SendToEtaWay { get; set; }

        [StringLength(18)]
        public string SendWayName { get; set; }

        public int? ItemFlag { get; set; }

        [StringLength(10)]
        public string ItemFlagName { get; set; }

        public int? PriceFlag { get; set; }

        [StringLength(10)]
        public string PriceFlagName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(300)]
        public string databaseConnGet { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(300)]
        public string databaseConnSet { get; set; }

        public byte? DBSetType { get; set; }

        public byte? DBGetType { get; set; }

        [StringLength(10)]
        public string DBGetTypeName { get; set; }

        [StringLength(10)]
        public string DBSetTypeName { get; set; }

        [StringLength(150)]
        public string loginUrl { get; set; }

        [StringLength(150)]
        public string SubmitReceipt_url { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string QR_url { get; set; }

        [StringLength(50)]
        public string mailFrom { get; set; }

        [StringLength(200)]
        public string maillTo { get; set; }

        [StringLength(50)]
        public string sendrPassword { get; set; }

        [StringLength(50)]
        public string Smtp_Server_Port { get; set; }

        [StringLength(50)]
        public string Smtp_Server_Host { get; set; }

        public DateTime? PosLastRunning { get; set; }

        [StringLength(161)]
        public string LastLogin { get; set; }

        [StringLength(400)]
        public string CallApi_URL { get; set; }

        [StringLength(400)]
        public string CallApi_CONSUMERKEY { get; set; }

        [StringLength(400)]
        public string CallApi_CONSUMERSECRET { get; set; }

        [StringLength(400)]
        public string CallApi_TOKENKEY { get; set; }

        [StringLength(400)]
        public string CallApi_TOKENSECRET { get; set; }

        [StringLength(40)]
        public string CallApi_Realm { get; set; }

        [StringLength(40)]
        public string CallApi_script { get; set; }

        [StringLength(50)]
        public string CallApi_deploy { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CallApi_ComID { get; set; }

        [StringLength(50)]
        public string DashboardResponseTable { get; set; }

        public int? LaoclStoreID { get; set; }
    }
}
