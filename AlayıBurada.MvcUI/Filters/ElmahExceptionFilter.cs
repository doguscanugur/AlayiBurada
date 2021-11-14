using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Filters
{
    public class ElmahExceptionFilter : IExceptionFilter
    {
        //Elmah hata logladığı zaman, 404 fırlatınca yakalamıyor. bunun önüne geçmek için bu class'ı yarattık.
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            }
        }
    }
}