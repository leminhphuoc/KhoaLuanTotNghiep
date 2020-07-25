using FonNature.Filter;
using FonNature.Services.IServices;
using Models.Entity;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class CustomerAdminController : Controller
    {
        private readonly ICustomerAdminServices _customerAdminServices;
        public CustomerAdminController(ICustomerAdminServices customerAdminServices)
        {
            _customerAdminServices = customerAdminServices;
        }
        // GET: Admin/ProductAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listCustomer = _customerAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listProductPaged = listCustomer.ToPagedList(pageNumber, pageSize);
            return View(listProductPaged);
        }

        public ActionResult Edit(int id)
        {
            var product = _customerAdminServices.GetDetail(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var editCustomerSuccess = _customerAdminServices.Edit(customer);
                if (!editCustomerSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _customerAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _customerAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }

    }
}