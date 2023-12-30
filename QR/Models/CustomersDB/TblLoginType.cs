namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblLoginType")]
    public partial class TblLoginType
    {
        [StringLength(50)]
        public string LoginType { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }
    }
}
