namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblAssignFunction
    {
        public int? Group_RecordID { get; set; }

        public int? Function_RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [Key]
        public int RecordID { get; set; }
    }
}
