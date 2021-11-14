using AlayıBurada.MvcUI.App_Start;
using AlayıBurada.MvcUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlayıBurada.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory()); //DI
            GlobalFilters.Filters.Add(new ElmahExceptionFilter()); // Elmah'ın yakalaması için
            GlobalFilters.Filters.Add(new HandleErrorAttribute()); //404 veya hataile karşılaşıldığında tüm projede hata alabilmek için.

        }
    }
}
