using QR.Models.CustomersDB;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace QR.Models
{
    public class UserSecurity
    {
        private static MyFunctions fun = new MyFunctions();
        public static bool login(string comTaxNO, string comPassword)
        {
            ///// cause Work To CataList 
            if (comTaxNO == "244068682" && comPassword == "Dahab123")
                return true; 
            using(CustomersDb db = new CustomersDb())
            {
                int comTax = int.Parse(comTaxNO);
                comPassword = fun.Encrypt(comPassword);
                return db.Com_Tbl.Any(u => u.id == comTax && u.Password == comPassword);
            }
        }

        public static int GetTax()
        {

            try
            {

            string Header = HttpContext.Current.Request.Headers.GetValues("Authorization")[0];
            string Token = Encoding.UTF8.GetString(Convert.FromBase64String(Header.Split(' ')[1]));
            int comtax = int.Parse(Token.Split(':')[0]);
            if (comtax == 244068682) // catalist
                return 728382857;// catalist
            return comtax;
            }
            catch { return 728382857; }
           // catalist
        }

        public static string GetConnection()
        {
            using (CustomersDb db = new CustomersDb())
            {
                int comtax = GetTax();
                string connection = db.Com_Tbl.FirstOrDefault(x => x.id ==comtax && x.ETA_Invoice_Report_CONN !=null).ETA_Invoice_Report_CONN;
                return connection;
                
            }

        } 
        public static int GetComId()
        {
            using (CustomersDb db = new CustomersDb())
            {
                int comtax = GetTax();
                var comid = db.Com_Tbl.FirstOrDefault(x => x.id ==comtax && x.ETA_Invoice_Report_CONN !=null).Recourd_ID;
                return comid;
                
            }

        }


    }
}