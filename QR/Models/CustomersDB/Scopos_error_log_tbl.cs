namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Scopos_error_log_tbl
    {
        [Key]
        public int Record_Id { get; set; }

        [StringLength(200)]
        public string ReceiptNumber { get; set; }

        [StringLength(200)]
        public string uuid { get; set; }

        [StringLength(2000)]
        public string message { get; set; }

        [StringLength(2000)]
        public string target { get; set; }

        [StringLength(2000)]
        public string Response { get; set; }
    }
}
