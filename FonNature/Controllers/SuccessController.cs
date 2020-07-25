using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("success")]
    [Route("{action=SuccessPage}")]
    public class SuccessController : Controller
    {
        // GET: Success
        public ActionResult SuccessPage(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public ActionResult OrderSuccessPage(long orderID)
        {
            ViewBag.orderID = orderID;
            return View();
        }
    }
}