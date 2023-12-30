namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblPasswordHistory")]
    public partial class TblPasswordHistory
    {
        [StringLength(50)]
        public string Password { get; set; }

        public int? User_RecordID { get; set; }

        public DateTime? TimeStamp { get; set; }

        [Key]
        public int RecordID { get; set; }
    }
}
