using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QR.Models
{
    public class UserSecurity
    {
        public static bool login(string username, string password)
        {
            using(QR.APIAuthEntities db = new APIAuthEntities())
            {
                return db.Users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            }
        }
    }
}