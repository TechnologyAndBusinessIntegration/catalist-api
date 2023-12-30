using Newtonsoft.Json;
using QR.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace QR.BL
{
    public class CallApi
    {
        private MyFunctions fun = new MyFunctions();
        private string client_id { get; set; }
        private string client_secret { get; set; }
        private string Api_URl { get; set; }
        private string TaxId { get; set; }
        private string customersconnection  = "Data Source=A2NWPLSK14SQL-v06.shr.prod.iad2.secureserver.net;Initial Catalog=SCOPOS_INV_Customers_DB;Persist Security Info=True;User ID= INV_Rotana;Password=T81@1NV#2o2IT02oo2;Timeout=0";
        public CallApi()
        {
            int ComTaxNumber = UserSecurity.GetTax();
            // 728382857
            // Get Date O DigiTech 
            string q = $@"SELECT DocumentSubmissions_URL, Login_URL ,client_id,client_secret 
                    FROM [dbo].[ETA_document_Tbl] 
                    where Com_TAx_No ='{ComTaxNumber}'and Environment_ID = 2 ";
            DataTable dt = fun.fireDataTableSQl(q,customersconnection);
            try
            {

                this.client_id = (string)dt.Rows[0]["client_id"];
                this.client_secret = (string)dt.Rows[0]["client_secret"];
                this.TaxId = $"{ComTaxNumber}";
                this.Api_URl = (string)dt.Rows[0]["DocumentSubmissions_URL"];
            }
            catch { }
        }

        private  Token Login( string scope = "InvoicingAPI")
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            var client = new RestClient("https://id.eta.gov.eg/connect/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "3f6bf69972563c3e0e619b78edf73035=d9c1a20894c4897c5b2a999aef6c20e7");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("scope", scope);
            IRestResponse response = client.Execute(request);

            //Console.WriteLine(response.Content);
            var settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            Token result = JsonConvert.DeserializeObject<Token>(response.Content, settings);
            if (response.Content != null && response.Content != "")
            {
                string s = result.ToString();
                return result;
            }
            else
            {
                throw (new Exception(response.ErrorMessage));
            }


        }
        public byte[] DocumentPrint( string invoiceUID)
        {
            Token token = Login();
            string endpoint = $"{Api_URl}/api/v1/documents/{invoiceUID}/pdf"; 
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Cookie", "75fd0698a2e84d6b8a3cb94ae54530f3=1fbf937b07a841d5da563aedc4f24f0d");
            var response = client.DownloadData(request);
            return response;
        }
















        //-----------------------------------------------------------------------------------------------

    }
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string error { get; set; }
        public Token() { }
        public Token(string access_token_, string expires_in_, string token_type_, string scope_, string error_)
        {
            this.access_token = access_token_;
            this.expires_in = expires_in_;
            this.token_type = token_type_;
            this.scope = scope_;
            this.error = error_;
        }
        public override string ToString()
        {
            string result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
}