using FonNature.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace FonNature.Filter
{
    public class AuthData : ActionFilterAttribute, IAuthenticationFilter 
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
                //Redirecting the user to the Login View of Account Controller
                filterContext.Result = new RedirectToRouteResult(
              new RouteValueDictionary(new { Controller = "LoginAdmin", Action = "Index", Area = "Admin" }));
                //If you want to redirect to some error view, use below code
                //filterContext.Result = new ViewResult()
                //{
                //    ViewName = "Login"
                //};
            }
        }
       
    }
}