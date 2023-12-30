namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Items_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        [StringLength(100)]
        public string Barcode { get; set; }

        public string Description { get; set; }

        [StringLength(400)]
        public string ETA_codeName { get; set; }

        [StringLength(255)]
        public string ETA_descriptionAr { get; set; }

        [StringLength(255)]
        public string ETA_description { get; set; }

        [StringLength(100)]
        public string ETA_active { get; set; }

        [StringLength(100)]
        public string ETA_status { get; set; }

        [StringLength(50)]
        public string parentItemCode { get; set; }

        [StringLength(500)]
        public string parentCodeName { get; set; }

        [StringLength(500)]
        public string parentCodeNameAr { get; set; }

        [StringLength(500)]
        public string level1_name { get; set; }

        [StringLength(500)]
        public string level1_nameAr { get; set; }

        [StringLength(500)]
        public string level2_name { get; set; }

        [StringLength(500)]
        public string level2_nameAr { get; set; }

        [StringLength(500)]
        public string level3_name1 { get; set; }

        [StringLength(500)]
        public string level3_nameAr1 { get; set; }
    }
}
