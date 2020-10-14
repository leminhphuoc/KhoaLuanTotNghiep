using FonNature.Filter;
using Models.Entity;
using Models.Repository;
using System.Web.Mvc;
namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class BenefitAdminController : Controller
    {
        private readonly IBenefitRepository _repository;
        public BenefitAdminController(IBenefitRepository repository)
        {
            _repository = repository;
        }
        public ActionResult BenefitList()
        {
            var model = _repository.GetBenefits();
            return View(model);
        }

        public ActionResult BenefitCreate()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult BenefitCreate(Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                var idBanner = _repository.Add(benefit);
                if (idBanner == 0) ModelState.AddModelError("", "Cannot Add benefit!");
                return RedirectToAction("BenefitList");
            }
            return View(benefit);
        }
    }
}