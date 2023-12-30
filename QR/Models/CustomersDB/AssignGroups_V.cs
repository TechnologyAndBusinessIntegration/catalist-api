namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignGroups_V
    {
        public int? User_RecordID { get; set; }

        public int? Group_RecordID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecordID { get; set; }

        public int? AuthenticationRequired { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(150)]
        public string UserName { get; set; }
    }
}
