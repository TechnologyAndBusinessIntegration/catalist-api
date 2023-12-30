namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(100)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? status { get; set; }

        public int? branchID { get; set; }
    }
}
