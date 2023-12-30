namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblAttachedFile
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string CustomerID { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }
    }
}
