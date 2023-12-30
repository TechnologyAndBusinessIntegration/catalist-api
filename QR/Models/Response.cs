using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR.Models
{
    public class Response<T> where T : class
    {
        public int state { get; set; }
        public T data { get; set; }
        public string message { get; set; }
       
    }
}