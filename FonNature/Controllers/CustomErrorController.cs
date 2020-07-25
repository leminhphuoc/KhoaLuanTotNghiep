using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        [HandleError]
        public ActionResult DefaultError()
        {
            return View();
        }
    }
}