namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_Users
    {
        public int? Group_RecordID { get; set; }

        [StringLength(150)]
        public string UserName { get; set; }

        [StringLength(300)]
        public string UserAccount { get; set; }

        [StringLength(300)]
        public string Password { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public int? LoginType { get; set; }

        public int? AccountIsDisabled { get; set; }

        public int? AccountsIsLockedOut { get; set; }

        public int? LoginState { get; set; }

        public int? AuthenticationRequired { get; set; }

        [StringLength(50)]
        public string Manager_RecordID { get; set; }

        public int? Branch_RecordID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecordID { get; set; }

        public DateTime? LastPasswordUpdate { get; set; }

        public int? PasswordNeverExpires { get; set; }

        public int? UserCannotChangePassword { get; set; }

        public int? UserMustChangePasswordAtNextLogon { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [StringLength(100)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? status { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        public int? branchID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ComID { get; set; }

        public int? Comp_TAX { get; set; }

        public int? MainComID { get; set; }

        [StringLength(100)]
        public string FunctionName { get; set; }
    }
}
