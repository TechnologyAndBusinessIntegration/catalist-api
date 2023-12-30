using Newtonsoft.Json;
using QR.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using static QR.Models.CallAPI;
using QR.Helpers;
using E_Inv_IntegrationLibrary_v2;
using QR.BL;
using QR.BL.APISCalls;

namespace QR.Controllers
{
   
    public class ReceiptController : ApiController
    {
        private GetReceiptPdf rpdf = new GetReceiptPdf();
        private IReceiptService RServ = new ReceiptService();


        [HttpGet,Route("~/TestToken")]
        public IHttpActionResult Token()
        {
            string connection = UserSecurity.GetConnection();
            int ComID = UserSecurity.GetComId();
            return Ok("All is Ok : com " + ComID);
        }

        [HttpPost , Route("~/api/Receipt/SaveReceipts")]
        public IHttpActionResult SaveReceipts( [FromBody] API_Root ReceiptJSON )
        {
            try
            {
                List<Invoice> AllReceipts = ReceiptJSON.invoices.ToList();
                ValidateAndUnValidateReceipts result = RServ.GetValidReceipts(AllReceipts);
                if(result.SucessModels != null && result.SucessModels.Count != 0)
                {
                    RServ.SaveValidInvoices(result.SucessModels);// save valid receipts to data base 
                    
                }
                if (result.FailedModels != null && result.FailedModels.Count != 0)
                {
                    RServ.SaveFailedInvoices(result.FailedModels);// save valid receipts to data base 

                }
                // filter response , return 

                if (result.FailedModels.Count == 0 && result.SucessModels.Count == 0) // no fail 
                {
                    return Ok(new Response<string> { state = 4, data = null, message = $" لا يوجد فواتير , من فضلك ادخل البيانات بطريقة صحيحة  " });
                }
                if (result.FailedModels == null || result.FailedModels.Count ==0) // no fail 
                {
                    return Ok(new Response<string> { state = 1, data = null, message = $" لا يوجد اي اخطاء في الفواتير وتم حفظ عدد {result.SucessModels.Count} فواتير  في قواعد البيانات بنجاح " });
                }
                if(result.SucessModels == null || result.SucessModels.Count ==0)  // no sucess  
                {
                    return Ok(new Response<List<Invoice>> { state = 3, data = result.FailedModels, message = $" لم يتم تسجيل اي فاتورة من {result.FailedModels.Count} , هذه الفواتير لم تسجل لوجود خطا في البيانات اما في العناصر او في العميل او في الفاتورة " });
                }
                // some sucess some fail 
              return Ok(new Response<List<Invoice>> {state = 2 ,message=$"تم تسجيل {result.SucessModels.Count} عدد فاتورة بنجاح , ولم يتم تسجيل عدد { result.FailedModels.Count} فواتير  , هذه الفواتير لم تسجل لوجود خطا في البيانات اما في العناصر او في العميل او في الفاتورة ", data = result.FailedModels  });
            }
            catch(Exception Ex)
            {
                return Ok(new Response<string> { state = 500 , message = "حدث خطا ما اثناء اجراء تسجيل الفواتير "});  
            }
        }
        [HttpGet,Route("~/api/Receipt/ReceiptResponse")]
        public IHttpActionResult ReceiptResponse (string BillNo  ,string DocType)
        {
            var response = RServ.GetBillResponse(BillNo, DocType.Trim().ToUpper());
            return Ok(new Response<BillResponseVM>() {state = 1 , data= response , message="Bill Response API " });
        }

        [HttpGet,Route("~/api/Receipt/GetReceiptPdf")]
        public IHttpActionResult GetReceiptPdf(string BillNo , string DocType)
        {
            try
            {
                string uuid = RServ.GetReceiptuuidbyBillNo(BillNo, DocType);
                byte[] response = rpdf.GetDocumentAsArrayOfByte( uuid );
                    return Ok(new Response<byte[]>() { state = 1 , data=response});
            }
            catch
            {
                return Ok(new Response<byte[]> { state = 2, data = new byte[] { } });
            }
        }
        [HttpGet, Route("~/api/Receipt/GetReceiptDetails")]
        public IHttpActionResult GetReceiptDetails(string BillNo) => Ok(RServ.GetReceiptByBillNo(BillNo));

        [HttpGet , Route("~/api/PrintDocument")]
        public IHttpActionResult Print(string uuid)
        {
            try
            {

                CallApi callApi = new CallApi();
                byte[] pdf = callApi.DocumentPrint(uuid);
                //if(pdf !=null && pdf.Length>0)
                //System.IO.File.WriteAllBytes($@"D:\TBI Folder\{uuid}.pdf", pdf);
                if (pdf != null && pdf.Length > 0)
                {
                    Response<byte[]> response = new Response<byte[]>()
                {
                    state = 1,
                    data = pdf,
                    message = $"{uuid} Pdf "
                };
                return Ok(response);
                }
                return Ok(new Response<byte[]> { state = 2, data = null, message = $"NO Invoice Found With UUID {uuid}" });
            }catch(Exception ex)
            {

                Response<byte[]> response = new Response<byte[]>()
                {
                    state = 500,
                    data = null,
                    message = "Error Ocured When Processing Request"
               
                };
                return Ok(response);
            }

        }

    }
}