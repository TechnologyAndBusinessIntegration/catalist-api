namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblFunction
    {
        [StringLength(100)]
        public string FunctionName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Key]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        public int? Perm { get; set; }
    }
}
