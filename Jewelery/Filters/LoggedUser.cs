using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.Filters
{
    public class LoggedUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["LoggedUser"] == null)
            {
                filterContext.Result = new RedirectResult("~");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}