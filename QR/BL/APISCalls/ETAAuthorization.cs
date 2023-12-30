using Antlr.Runtime.Misc;
using BavariaCasheir.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace QR.BL.APISCalls
{
    public class ETAAuthorization
    {
        MyFunctions Dfun = new MyFunctions();
        string DBConnection = "Data Source=A2NWPLSK14SQL-v06.shr.prod.iad2.secureserver.net;Initial Catalog=SCOPOS_INV_Customers_DB;Persist Security Info=True;User ID= INV_Rotana;Password=T81@1NV#2o2IT02oo2;Timeout=0";
         public ETA_document_Tbl GetLogin()
         {
            string getCompanyETAData = $"select * from COM_INFO_Inv_WS_V where comid = {1} and status = 1 ";// 1=> TBICompany
            DataTable Logdt = Dfun.fireDataTableSQl(getCompanyETAData,DBConnection);
            ETA_document_Tbl LoginInfo = Helpers.Converter.ConvertDataTable<ETA_document_Tbl>(Logdt).FirstOrDefault();
            return LoginInfo;
                

          }
        public Token Login(string url, string client_id, string client_secret, string scope)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

            var client = new RestClient(url);
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




    }
}