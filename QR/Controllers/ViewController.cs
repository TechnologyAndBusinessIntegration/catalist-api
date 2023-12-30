using QR.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QR.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        [Route("~/View")]
        public ActionResult Index(string uuid )
        {
            CallApi callApi = new CallApi();
            byte[] pdf = callApi.DocumentPrint(uuid);
            return File(pdf,"application/pdf");
        }
    }
}