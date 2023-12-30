namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measurement_Units_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string Measurement_Units { get; set; }
    }
}
