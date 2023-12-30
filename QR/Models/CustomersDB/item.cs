namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("item")]
    public partial class item
    {
        [StringLength(20)]
        public string BinLocation { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "money")]
        public decimal BuydownPrice { get; set; }

        [Key]
        [Column(Order = 1)]
        public double BuydownQuantity { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal CommissionAmount { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal CommissionMaximum { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommissionMode { get; set; }

        [Key]
        [Column(Order = 5)]
        public float CommissionPercentProfit { get; set; }

        [Key]
        [Column(Order = 6)]
        public float CommissionPercentSale { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool FoodStampable { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HQID { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool ItemNotDiscountable { get; set; }

        public DateTime? LastReceived { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime LastUpdated { get; set; }

        [Key]
        [Column(Order = 11)]
        public double QuantityCommitted { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNumberCount { get; set; }

        [Key]
        [Column(Order = 13)]
        public double TareWeightPercent { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int storeid { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(25)]
        public string ItemLookupCode { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        [Key]
        [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageID { get; set; }

        [Key]
        [Column(Order = 20, TypeName = "money")]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 21, TypeName = "money")]
        public decimal PriceA { get; set; }

        [Key]
        [Column(Order = 22, TypeName = "money")]
        public decimal PriceB { get; set; }

        [Key]
        [Column(Order = 23, TypeName = "money")]
        public decimal PriceC { get; set; }

        [Key]
        [Column(Order = 24, TypeName = "money")]
        public decimal SalePrice { get; set; }

        public DateTime? SaleStartDate { get; set; }

        public DateTime? SaleEndDate { get; set; }

        [Key]
        [Column(Order = 25)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuantityDiscountID { get; set; }

        [Key]
        [Column(Order = 26)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxID { get; set; }

        [Key]
        [Column(Order = 27)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ItemType { get; set; }

        [Key]
        [Column(Order = 28, TypeName = "money")]
        public decimal Cost { get; set; }

        [Key]
        [Column(Order = 29)]
        public double Quantity { get; set; }

        [Key]
        [Column(Order = 30)]
        public double ReorderPoint { get; set; }

        [Key]
        [Column(Order = 31)]
        public double RestockLevel { get; set; }

        [Key]
        [Column(Order = 32)]
        public double TareWeight { get; set; }

        [Key]
        [Column(Order = 33)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierID { get; set; }

        [Key]
        [Column(Order = 34)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagAlongItem { get; set; }

        [Key]
        [Column(Order = 35)]
        public double TagAlongQuantity { get; set; }

        [Key]
        [Column(Order = 36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParentItem { get; set; }

        [Key]
        [Column(Order = 37)]
        public double ParentQuantity { get; set; }

        [Key]
        [Column(Order = 38)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short BarcodeFormat { get; set; }

        [Key]
        [Column(Order = 39, TypeName = "money")]
        public decimal PriceLowerBound { get; set; }

        [Key]
        [Column(Order = 40, TypeName = "money")]
        public decimal PriceUpperBound { get; set; }

        [StringLength(50)]
        public string PictureName { get; set; }

        public DateTime? LastSold { get; set; }

        [StringLength(30)]
        public string SubDescription1 { get; set; }

        [StringLength(30)]
        public string SubDescription2 { get; set; }

        [StringLength(30)]
        public string SubDescription3 { get; set; }

        [StringLength(4)]
        public string UnitOfMeasure { get; set; }

        [Key]
        [Column(Order = 41)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubCategoryID { get; set; }

        [Key]
        [Column(Order = 42)]
        public bool QuantityEntryNotAllowed { get; set; }

        [Key]
        [Column(Order = 43)]
        public bool PriceMustBeEntered { get; set; }

        [StringLength(30)]
        public string BlockSalesReason { get; set; }

        public DateTime? BlockSalesAfterDate { get; set; }

        [Key]
        [Column(Order = 44)]
        public double Weight { get; set; }

        [Key]
        [Column(Order = 45)]
        public bool Taxable { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] DBTimeStamp { get; set; }

        public DateTime? BlockSalesBeforeDate { get; set; }

        [Key]
        [Column(Order = 46, TypeName = "money")]
        public decimal LastCost { get; set; }

        [Key]
        [Column(Order = 47, TypeName = "money")]
        public decimal ReplacementCost { get; set; }

        [Key]
        [Column(Order = 48)]
        public bool WebItem { get; set; }

        [Key]
        [Column(Order = 49)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlockSalesType { get; set; }

        [Key]
        [Column(Order = 50)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlockSalesScheduleID { get; set; }

        [Key]
        [Column(Order = 51)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleType { get; set; }

        [Key]
        [Column(Order = 52)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleScheduleID { get; set; }

        [Key]
        [Column(Order = 53)]
        public bool Consignment { get; set; }

        [Key]
        [Column(Order = 54)]
        public bool Inactive { get; set; }

        public DateTime? LastCounted { get; set; }

        [Key]
        [Column(Order = 55)]
        public bool DoNotOrder { get; set; }

        [Key]
        [Column(Order = 56, TypeName = "money")]
        public decimal MSRP { get; set; }

        [Key]
        [Column(Order = 57)]
        public DateTime DateCreated { get; set; }

        [StringLength(255)]
        public string UsuallyShip { get; set; }

        [StringLength(20)]
        public string NumberFormat { get; set; }

        public bool? ItemCannotBeRet { get; set; }

        public bool? ItemCannotBeSold { get; set; }

        public bool? IsAutogenerated { get; set; }

        [Key]
        [Column(Order = 58)]
        public bool IsGlobalvoucher { get; set; }

        public bool? DeleteZeroBalanceEntry { get; set; }

        [Key]
        [Column(Order = 59)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TenderID { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [Key]
        [Column(Order = 60, TypeName = "ntext")]
        public string ExtendedDescription { get; set; }

        [Key]
        [Column(Order = 61, TypeName = "ntext")]
        public string Content { get; set; }
    }
}
