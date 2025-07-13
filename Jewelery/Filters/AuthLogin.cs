using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jewelery.Filters
{
    public class AuthLogin(IHttpContextAccessor httpContextAccessor) : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_httpContextAccessor.HttpContext.Current.Session["Admin"] == null)
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