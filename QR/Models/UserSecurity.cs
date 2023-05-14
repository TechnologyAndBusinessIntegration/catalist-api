using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QR.Models
{
    public class UserSecurity
    {
        public static bool login(string comTaxNO, string comPassword)
        {
            using(QR.Scopos_Customers_DBEntities db = new Scopos_Customers_DBEntities())
            {
                int comTax = int.Parse(comTaxNO);
                return db.Com_Tbl.Any(u => u.id == comTax && u.Password == comPassword);
            }
        }
    }
}