using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyClinic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie =
                Context.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                System.Web.Security.FormsAuthenticationTicket authTicket =
                    System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);

                string[] roles = authTicket.UserData.Split(new Char[] { ',' });

                GenericPrincipal userPrincipal =
                    new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);

                Context.User = userPrincipal;
                System.Threading.Thread.CurrentPrincipal = userPrincipal;
            }
        }
    }
}
