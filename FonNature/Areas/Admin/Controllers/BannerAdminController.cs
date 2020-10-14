using FonNature.Filter;
using Models.Entity;
using Models.Repository;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class BannerAdminController : Controller
    {
        private readonly IBannerRepository _bannerRepository;
        public BannerAdminController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        // GET: Admin/Banner
        public ActionResult BannerList()
        {
            var model = _bannerRepository.GetList();
            return View(model);
        }
        public ActionResult BannerCreate()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult BannerCreate(Banner banner)
        {
            if (ModelState.IsValid)
            {
                var idBanner = _bannerRepository.Add(banner);
                if (idBanner == 0) ModelState.AddModelError("", "Cannot Add Banner!");
                return RedirectToAction("BannerList");
            }
            return View(banner);
        }

        public ActionResult BannerEdit(int id)
        {
            var banner = _bannerRepository.GetDetail(id);
            if (banner == null) return RedirectToAction("BannerList");
            return View(banner);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult BannerEdit(Banner banner)
        {
            if (ModelState.IsValid)
            {
                var isEditSuccess = _bannerRepository.Edit(banner);
                if (!isEditSuccess) ModelState.AddModelError("", "Cannot Edit Banner!");
                return RedirectToAction("BannerList");
            }
            return View(banner);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _bannerRepository.Delete(id);
            return RedirectToAction("BannerList");
        }
    }
}