using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jewelery.Filters
{
    //TODO clasin cagrildigi yeri bilmirik
    public class LoggedUser(IHttpContextAccessor httpContextAccessor) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (httpContextAccessor.HttpContext?.Session.GetString("LoggedUser") == null)
            {
                filterContext.Result = new RedirectResult("~");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}