namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LicenseTbl")]
    public partial class LicenseTbl
    {
        [Key]
        public int Recourd_ID { get; set; }

        [StringLength(150)]
        public string ComName { get; set; }

        [StringLength(150)]
        public string TaxNumber { get; set; }

        [StringLength(150)]
        public string DBName { get; set; }

        [StringLength(150)]
        public string DBAccount { get; set; }

        [StringLength(50)]
        public string DBPassword { get; set; }

        [StringLength(150)]
        public string SetteingDBNAME { get; set; }

        public string Conn { get; set; }

        public string Logger { get; set; }
    }
}
