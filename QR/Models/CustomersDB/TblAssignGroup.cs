namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblAssignGroup")]
    public partial class TblAssignGroup
    {
        public int? User_RecordID { get; set; }

        public int? Group_RecordID { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }
    }
}
