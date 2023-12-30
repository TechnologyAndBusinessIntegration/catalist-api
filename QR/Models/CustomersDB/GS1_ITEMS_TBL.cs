namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GS1_ITEMS_TBL
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string Barcode { get; set; }

        [StringLength(500)]
        public string codeName { get; set; }

        [StringLength(500)]
        public string codeNameAr { get; set; }

        [StringLength(500)]
        public string descriptionAr { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [StringLength(500)]
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
        public string level3_name { get; set; }

        [StringLength(500)]
        public string level3_nameAr { get; set; }
    }
}
