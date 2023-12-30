namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignSales_V
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string NationalID { get; set; }

        [StringLength(100)]
        public string Telephone1 { get; set; }

        [StringLength(100)]
        public string Telephone2 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? status { get; set; }

        public int? Department_ID { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        public string Comment { get; set; }
    }
}
