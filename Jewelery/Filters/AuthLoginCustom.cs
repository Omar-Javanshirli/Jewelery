using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jewelery.Filters
{
    public class AuthLoginCustom : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Todo Program.cs filana cixmalidir.
            var context = new HttpContextAccessor();
            if (context.HttpContext?.Session.GetString("Admin") == null)
            {
                filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                    { "controller", "Login" },
                    { "action", "Index" }
            });
                return;
            }
            
            
            base.OnActionExecuting(filterContext);
        }
    }
}