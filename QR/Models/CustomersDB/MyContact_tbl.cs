namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyContact_tbl
    {
        [StringLength(50)]
        public string TeleponeNumber { get; set; }

        public int? WhatsAppSendMsgStatus { get; set; }

        [Key]
        public int Record_ID { get; set; }

        public DateTime? WhatsAppSendMsgTime { get; set; }
    }
}
