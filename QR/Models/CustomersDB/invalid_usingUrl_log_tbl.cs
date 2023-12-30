namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class invalid_usingUrl_log_tbl
    {
        [StringLength(1000)]
        public string invalid_using { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? comid { get; set; }

        public DateTime? date { get; set; }
    }
}
