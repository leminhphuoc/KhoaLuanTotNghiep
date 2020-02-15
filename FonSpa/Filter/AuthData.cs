using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace FonNature.Filter
{
    public class AuthDataAttribute : ActionFilterAttribute, IAuthenticationFilter 
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["USER_SESSION_ADMIN"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
              new RouteValueDictionary(new { Controller = "LoginAdmin", Action = "Index", Area = "Admin" }));
            }
        }
       
    }
}