namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignFunctions_V
    {
        public int? Group_RecordID { get; set; }

        public int? Function_RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecordID { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(100)]
        public string FunctionName { get; set; }

        [StringLength(150)]
        public string UserName { get; set; }

        [StringLength(300)]
        public string UserAccount { get; set; }

        [StringLength(300)]
        public string Password { get; set; }

        public int? User_RecordID { get; set; }
    }
}
