namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblUser
    {
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
        public int RecordID { get; set; }

        public DateTime? LastPasswordUpdate { get; set; }

        public int? PasswordNeverExpires { get; set; }

        public int? UserCannotChangePassword { get; set; }

        public int? UserMustChangePasswordAtNextLogon { get; set; }

        [StringLength(100)]
        public string Editor { get; set; }

        public DateTime? Date { get; set; }

        public byte? status { get; set; }

        public int? Role { get; set; }

        public int? ComID { get; set; }
    }
}
