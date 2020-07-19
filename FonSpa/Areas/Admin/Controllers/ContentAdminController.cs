using FonNature.Services.IServices;
using System.Web.Mvc;
using PagedList;
using Models.Entity;
using FonNature.Filter;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class ContentAdminController : Controller
    {

        private readonly IContentServices _contentServices;
        public ContentAdminController(IContentServices contentServices)
        {
            _contentServices = contentServices;
        }
        // GET: Admin/ContentAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listContent = _contentServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listContentPaged = listContent.ToPagedList(pageNumber, pageSize);
            ViewBag.Category = _contentServices.GetContentCategory();
            return View(listContentPaged);
        }

        public ActionResult Create()
        {
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                foreach (var tag in Constant.HtmlTagWhiteList)
                {
                    content.description = content.description.Replace("</" + tag + ">", "&lt;" + tag + "/&gt;");
                }
                if (content.description.Contains("</")) ModelState.AddModelError("", "Invalid Description!");
                else
                {
                    foreach (var tag in Constant.HtmlTagWhiteList)
                    {
                        content.description = content.description.Replace("&lt;" + tag + "/&gt;", "</" + tag + ">");
                    }
                    var addContent = _contentServices.AddContent(content);
                    var idContent = addContent;
                    if (idContent == 0) ModelState.AddModelError("", "Cannot Add Content!");
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }


        public ActionResult Edit(long id)
        {
            var content = _contentServices.GetDetail(id);
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Content content)
        {
            if(ModelState.IsValid)
            {
                var editSuccess = _contentServices.EditContent(content);
                if(editSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Edit fail !");
                }
            }
            ViewBag.ContentCategory = _contentServices.GetContentCategory();
            return View(content);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _contentServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _contentServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}