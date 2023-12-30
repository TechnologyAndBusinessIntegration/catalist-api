namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblDeal
    {
        public int? MOBILE { get; set; }

        [Column(TypeName = "money")]
        public decimal? OVD { get; set; }

        public DateTime? DEAL_DATE { get; set; }

        public DateTime? NEW_EMI_DATE { get; set; }

        [Column(TypeName = "money")]
        public decimal? DEAL_AMOUNT { get; set; }

        [Column(TypeName = "money")]
        public decimal? DEPOSIT { get; set; }

        [Column(TypeName = "money")]
        public decimal? NEW_EMI { get; set; }

        [Column("1ST_MONTH")]
        public DateTime? C1ST_MONTH { get; set; }

        public int? TENOR { get; set; }

        [Column(TypeName = "money")]
        public decimal? WAIVED_AMOUNT { get; set; }

        [StringLength(255)]
        public string ACTION_TRUE { get; set; }

        [StringLength(255)]
        public string LEGAL { get; set; }

        [StringLength(255)]
        public string LETTER { get; set; }

        [StringLength(255)]
        public string CALL_RECORDED_TIME { get; set; }

        [StringLength(255)]
        public string EXT { get; set; }

        [StringLength(255)]
        public string AGENCY { get; set; }

        [StringLength(255)]
        public string OFFICER { get; set; }

        public string NOTES { get; set; }

        [StringLength(255)]
        public string user_name { get; set; }

        public DateTime? Time { get; set; }

        public int? ACC { get; set; }

        public int? ID { get; set; }

        [Key]
        public int RecordID { get; set; }

        [StringLength(255)]
        public string CUSTOMER { get; set; }
    }
}
