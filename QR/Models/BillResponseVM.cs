using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR.Models
{
    public class BillResponseVM
    {
        public string  BillNo { get; set; }
        public string  Response  { get; set; }
        public int Status { get; set; }
        public string DocymentType { get; set; }
        public DateTime? BillDate { get; set; }
    }
}