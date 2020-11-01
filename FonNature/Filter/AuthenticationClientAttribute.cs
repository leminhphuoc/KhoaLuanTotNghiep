using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace FonNature.Filter
{
    public class AuthenticationClientAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var sessionValue = filterContext.HttpContext.Session[Constant.Membership.IsLoginSession];
            var isLogin = false;
            if(sessionValue != null)
            {
                isLogin = (bool)sessionValue;
            }
            if (!isLogin)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { Controller = "Home", Action = "Home" }));
            }
        }
    }
}