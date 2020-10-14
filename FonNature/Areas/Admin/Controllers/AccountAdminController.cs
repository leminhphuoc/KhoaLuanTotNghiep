using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Repository;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class AccountAdminController : Controller
    {
        private readonly IAccountAdminRepository _accountAdminRepository;
        private readonly IAccountAdminServices _accountAdminServices;
        public AccountAdminController(IAccountAdminRepository accountAdminRepository, IAccountAdminServices accountAdminServices)
        {
            _accountAdminRepository = accountAdminRepository;
            _accountAdminServices = accountAdminServices;
        }
        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var listAccount = _accountAdminRepository.GetListAccount();
            return View(listAccount);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var res = _accountAdminRepository.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountAdmin accountAdmin, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (accountAdmin.passWord != confirmPassword) ModelState.AddModelError("", "Confirm password không chính xác !");
                else
                {
                    var addAccountSuccess = _accountAdminServices.CreateAccount(accountAdmin);
                    if (addAccountSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tài khoản đã tồn tại trong hệ thống !");
                    }
                }
            }
            return View(accountAdmin);
        }

        public ActionResult Edit(long id)
        {
            var account = _accountAdminRepository.GetDetail(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(AccountAdmin account, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (account.passWord != confirmPassword) ModelState.AddModelError("", "Confirm password không chính xác !");
                else
                {
                    var editAccountSuccess = _accountAdminServices.EditAccount(account);
                    if (editAccountSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(account);
        }


        [HttpDelete]
        public ActionResult DeleteAccount(int id)
        {
            _accountAdminRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}