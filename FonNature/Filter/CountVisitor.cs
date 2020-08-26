using System.Web.Mvc;

namespace FonNature.Filter
{
    public class CountVisitorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Active when publish web
        }
    }
}