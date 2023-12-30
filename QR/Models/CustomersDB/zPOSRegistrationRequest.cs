namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class zPOSRegistrationRequest
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(75)]
        public string CompanyName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(75)]
        public string TaxRegistration { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(75)]
        public string ContactEmail { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte BranchNo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string BranchAddress { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string ClientID { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string SecretID { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(75)]
        public string POSManufacturer { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(75)]
        public string POSModel { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(75)]
        public string POSDevice { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(75)]
        public string POSSerialNo { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(75)]
        public string POSOperating { get; set; }

        [Key]
        [Column(Order = 12)]
        public byte POSRam { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short POSRom { get; set; }

        [Key]
        [Column(Order = 14)]
        public DateTime RequestDate { get; set; }

        [Key]
        [Column(Order = 15)]
        public byte ResponseStatus { get; set; }
    }
}
