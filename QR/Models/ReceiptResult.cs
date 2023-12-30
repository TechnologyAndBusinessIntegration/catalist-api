using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR.Models
{
    public class ReceiptResult
    {
       
        public string documentType { get; set; }
        public string BillNo { get; set; }
        public string uuid { get; set; }
        public string validation { get; set; }
        public string Response { get; set; }
    }
}