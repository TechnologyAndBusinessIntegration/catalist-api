using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR.Helpers
{
    public static class TbiServer
    {
        public static string Now { get; set; } = DateTime.Now.AddDays(10).ToString("yyyy-MMM-dd hh:mm tt");
    }
}