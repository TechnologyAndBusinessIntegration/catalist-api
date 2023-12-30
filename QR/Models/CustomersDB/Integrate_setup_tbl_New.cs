namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Integrate_setup_tbl_New
    {
        [Key]
        public int Record_ID { get; set; }

        public int? Com_Tax_No { get; set; }

        public byte? DataSourceType { get; set; }

        public byte? DataResponseType { get; set; }

        public byte? InsertResponse { get; set; }

        [StringLength(200)]
        public string ExelFilePath { get; set; }

        [StringLength(200)]
        public string ExelFileBackupPath { get; set; }

        [StringLength(200)]
        public string ExelFileName { get; set; }

        [StringLength(100)]
        public string ExelTabName { get; set; }

        public string Mail { get; set; }

        public string fillGV { get; set; }

        public string FillDashboard { get; set; }

        public string SearchInvent_1 { get; set; }

        public string SearchInvent_2 { get; set; }

        [StringLength(100)]
        public string SetResponse_TableName { get; set; }

        [StringLength(100)]
        public string SetResponse_Response_ColName { get; set; }

        [StringLength(100)]
        public string SetResponse_validation_ColName { get; set; }

        [StringLength(100)]
        public string SetResponse_sendToetaStatus_ColName { get; set; }

        [StringLength(100)]
        public string SetResponse_sendToetaDate_ColName { get; set; }

        [StringLength(100)]
        public string SetResponse_InvNo_ColName { get; set; }

        [StringLength(100)]
        public string SetResponse_RecourdID_ColName { get; set; }

        public string DataSourceQuery_H_Re_Submit_Issues { get; set; }

        public string DataSourceQuery_H { get; set; }

        public string DataSourceQuery_D { get; set; }

        public string InsertResponseQuery { get; set; }

        [StringLength(1000)]
        public string GetAllValid_Query { get; set; }

        [StringLength(1000)]
        public string GetAllInValid_Query { get; set; }

        [StringLength(1000)]
        public string GetAllSubmet_Query { get; set; }

        [StringLength(1000)]
        public string GetAllUnSubmet_Query { get; set; }

        [StringLength(1000)]
        public string GetAllUnCanceld_Query { get; set; }

        [StringLength(1000)]
        public string GetAllUnReject_Query { get; set; }

        [StringLength(100)]
        public string FillDashPord { get; set; }

        [StringLength(100)]
        public string Linlk_H_With_D_By_ColName { get; set; }

        [StringLength(300)]
        public string GetReportSales { get; set; }

        [StringLength(300)]
        public string GetReportPurchases { get; set; }

        public byte? INV_with_Receipt { get; set; }

        [StringLength(100)]
        public string Select_Coll_30 { get; set; }

        [StringLength(100)]
        public string Select_Coll_31 { get; set; }

        [StringLength(100)]
        public string Select_Coll_32 { get; set; }

        [StringLength(100)]
        public string Select_Coll_33 { get; set; }

        [StringLength(100)]
        public string Select_Coll_34 { get; set; }

        [StringLength(100)]
        public string Select_Coll_35 { get; set; }

        [StringLength(100)]
        public string Select_Coll_36 { get; set; }

        [StringLength(100)]
        public string Select_Coll_37 { get; set; }

        [StringLength(100)]
        public string Select_Coll_38 { get; set; }

        [StringLength(100)]
        public string Select_Coll_39 { get; set; }

        [StringLength(100)]
        public string Select_Coll_40 { get; set; }

        [StringLength(150)]
        public string editor { get; set; }

        [StringLength(400)]
        public string SetResponseDB { get; set; }

        [StringLength(400)]
        public string DataSource_Conn { get; set; }

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

        public int? CallApi_ComID { get; set; }
    }
}
