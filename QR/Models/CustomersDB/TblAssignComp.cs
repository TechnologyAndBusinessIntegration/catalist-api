namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblAssignComp")]
    public partial class TblAssignComp
    {
        public int? Comp_TAX_No { get; set; }

        public int? Group_RecordID { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        public int? Com_ID { get; set; }
    }
}
