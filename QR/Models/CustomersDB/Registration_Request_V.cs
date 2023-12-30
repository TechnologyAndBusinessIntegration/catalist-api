namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registration_Request_V
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public int? BranchID { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        public string AndroidID { get; set; }

        [StringLength(50)]
        public string PosSerial { get; set; }

        public byte? Status { get; set; }

        [StringLength(8)]
        public string RequestStatues { get; set; }

        public int? ComID { get; set; }

        public DateTime? Date { get; set; }
    }
}
