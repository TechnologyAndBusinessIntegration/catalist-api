namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignCus_V
    {
        [StringLength(100)]
        public string Sales { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string CusTel1 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string CusAddress { get; set; }

        public string Comment { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public int? SalesContact_ID { get; set; }

        public byte? status { get; set; }

        public int? Department_ID { get; set; }

        [StringLength(100)]
        public string TaxRegistration { get; set; }
    }
}
