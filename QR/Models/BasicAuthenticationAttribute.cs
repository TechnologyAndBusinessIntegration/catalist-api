﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace QR.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] UandP = decodedAuthToken.Split(':');
                string uname = UandP[0];
                string password = UandP[1];

                var status = UserSecurity.login(uname, password);
                if (status)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(uname), null);

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}