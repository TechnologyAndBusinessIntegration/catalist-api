namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cus_Tbl
    {
        [Key]
        public int Record_ID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Telephone1 { get; set; }

        [StringLength(100)]
        public string TaxRegistration { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public string Comment { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string SalesContact { get; set; }

        public int? SalesContact_ID { get; set; }

        public byte? status { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string governate { get; set; }

        [StringLength(50)]
        public string regionCity { get; set; }

        [StringLength(50)]
        public string street { get; set; }

        [StringLength(50)]
        public string buildingNumber { get; set; }

        [StringLength(50)]
        public string postalCode { get; set; }

        [StringLength(50)]
        public string floor { get; set; }

        [StringLength(50)]
        public string room { get; set; }

        [StringLength(50)]
        public string landmark { get; set; }

        [StringLength(50)]
        public string additionalInformation { get; set; }

        [StringLength(50)]
        public string type { get; set; }
    }
}
