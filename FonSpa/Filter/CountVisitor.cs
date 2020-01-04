using Models.IRepository;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FonNature.Filter
{
    public class CountVisitor : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Active when publish web
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
                var addIpAddress = new IPAddressRepository().AddIpAddress(VisitorsIPAddr);
            }
        }
    }
}