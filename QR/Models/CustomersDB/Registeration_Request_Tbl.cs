namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registeration_Request_Tbl
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        public int? BranchID { get; set; }

        public string AndroidID { get; set; }

        [StringLength(50)]
        public string PosSerial { get; set; }

        public byte? Status { get; set; }

        public int? ComID { get; set; }

        public DateTime? Date { get; set; }
    }
}
