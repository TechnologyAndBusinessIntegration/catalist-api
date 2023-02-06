using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QR.Controllers
{
    public class QRController : ApiController
    {
        [HttpPost]
        [Route("api/QR/Create")]
        public IHttpActionResult CreateQR([FromBody] string qr)
        {
            string base64String = "This is an QR Code";
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var image = qrcode.Draw(qr, 50);
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, ImageFormat.Jpeg);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
            }
            return Ok(base64String);
        }
    }
}
