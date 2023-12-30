namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblError")]
    public partial class TblError
    {
        [Key]
        public int Record_ID { get; set; }

        public DateTime? Date { get; set; }

        public string Error { get; set; }

        public string Msg { get; set; }
    }
}
