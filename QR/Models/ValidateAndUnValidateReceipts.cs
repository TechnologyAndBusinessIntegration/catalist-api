using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static QR.Models.CallAPI;

namespace QR.Models
{
    public class ValidateAndUnValidateReceipts
    {
        public List<Invoice> SucessModels { get; set; } = new List<Invoice>();
        public List<Invoice> FailedModels { get; set; } = new List<Invoice>();

    }
}