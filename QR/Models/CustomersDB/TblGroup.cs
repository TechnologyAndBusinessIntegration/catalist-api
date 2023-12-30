namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblGroup
    {
        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        public byte? Status { get; set; }

        public int? MainGroup_ID { get; set; }
    }
}
