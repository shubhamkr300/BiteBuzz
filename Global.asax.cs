using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace FoodDeliveryApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //InitializeAuthenticationProcess();            
        }
        //private void InitializeAuthenticationProcess()
        //{
        //    if (!WebSecurity.Initialized)
        //    {
        //        WebSecurity.InitializeDatabaseConnection("const", "UserReg", "Userid", "Username", true);
        //        WebSecurity.CreateUserAndAccount("admin", "admin123");
        //        Roles.CreateRole("Administrator");
        //        Roles.CreateRole("User");
        //        Roles.AddUserToRole("admin","Administrator");

        //    }
        //}

    }
}
