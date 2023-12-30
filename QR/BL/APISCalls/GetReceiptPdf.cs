
using BavariaCasheir.Models;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QR.BL.APISCalls
{
    public class GetReceiptPdf
    {
        private ETAAuthorization eta = new ETAAuthorization();  
        public byte[] GetDocumentAsArrayOfByte(string invoiceUID)
        {
            try
            {

                ETA_document_Tbl etadata = eta.GetLogin(); /// get ETA login date user and secret 
                Token token = eta.Login(etadata.Login_URL, etadata.client_id, etadata.client_secret, "InvoicingAPI"); // get the token to call api 
              
                var request = new RestRequest(Method.GET);
                var client = new RestClient(etadata.DocumentSubmissions_URL + "api/v1/documents/" + invoiceUID + "/pdf");
                client.Timeout = -1;
                request.AddHeader("Authorization", "Bearer " + token.access_token);
                request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");

                 var response = client.DownloadData(request);
                if (response != null)
                {
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("content-length", response.Length.ToString());
                    HttpContext.Current.Response.BinaryWrite(response);
                    HttpContext.Current.Response.OutputStream.Write(response, 0, response.Length);
                    HttpContext.Current.Response.OutputStream.Flush();
                   return response;
                }
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
            return new byte[0];
        }
    }
}