namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RunningLog_tbl
    {
        [Key]
        public int Record_Id { get; set; }

        public DateTime? running_time { get; set; }

        public int? branshId { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        public int? inv_count { get; set; }

        [StringLength(1000)]
        public string running_feadback { get; set; }

        public int? SellerRin { get; set; }
    }
}
