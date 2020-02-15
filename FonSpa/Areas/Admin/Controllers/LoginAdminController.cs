using FonNature.Areas.Admin.Models;
using FonNature.Common;
using FonNature.Services.IServices;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        private readonly IAccountAdminServices _accountAdminServices;
        public LoginAdminController(IAccountAdminServices accountAdminServices)
        {
            _accountAdminServices = accountAdminServices;
        }
        public LoginAdminController()
        {

        }
        // GET: Admin/LoginAdmin 
        public ActionResult Index()
        {
            var loginModel = new LoginModel();
            if (Request.Cookies.AllKeys.Contains("username") && Request.Cookies["username"].Value != "")
            {
                loginModel.UserName = Request.Cookies["username"].Value.ToString();
            }
            if (Request.Cookies.AllKeys.Contains("password") && Request.Cookies["password"].Value != "")
            {
                loginModel.PassWord = Request.Cookies["password"].Value.ToString();
            }
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Index(LoginModel LoginModel)
        {

            if (LoginModel != null && ModelState.IsValid)
            {
                if (LoginModel.RememberMe)
                {
                    if (Request.Cookies["username"].Value == "")
                    {
                        Response.Cookies["username"].Value = LoginModel.UserName;
                    }
                    if (Request.Cookies["password"].Value == "")
                    {
                        Response.Cookies["password"].Value = LoginModel.PassWord;
                    }
                }

                var checklogin = _accountAdminServices.checkLoginAdmin(LoginModel);
                if (checklogin == 1)
                {

                    Session[CommonConstants.USER_SESSION_ADMIN] = "USER_SESSION_ADMIN";
                    return RedirectToAction("Index", "HomeAdmin");

                }
                else if (checklogin == 0)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập !");
                }
                else if (checklogin == -1)
                {
                    ModelState.AddModelError("", "Sai mật khẩu !");
                }
                else if (checklogin == -2)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa !");
                }
            }
            return View(LoginModel);
        }


    }
}