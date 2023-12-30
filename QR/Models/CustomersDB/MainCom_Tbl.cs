namespace QR.Models.CustomersDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainCom_Tbl
    {
        public int id { get; set; }

        [StringLength(200)]
        public string comName { get; set; }

        public int? Maincomid { get; set; }
    }
}
