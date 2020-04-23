using FonNature.Areas.Admin.Models;
using FonNature.Common;
using FonNature.Services.IServices;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

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
                    ReGenerateSessionId();

                    HttpCookie cookies = new HttpCookie("ck_authorized");
                    cookies.Value = "true";
                    cookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookies);

                    Session[CommonConstants.UserSession.USER_SESSION_ADMIN] = "USER_SESSION_ADMIN";
                    return RedirectToAction("HomeAdmin", "HomeAdmin");

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

        protected void ReGenerateSessionId()
        {
            SessionIDManager manager = new SessionIDManager();
            string oldId = manager.GetSessionID(System.Web.HttpContext.Current);
            string newId = manager.CreateSessionID(System.Web.HttpContext.Current);
            bool isAdd = false, isRedir = false;
            manager.RemoveSessionID(System.Web.HttpContext.Current);
            manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedir, out isAdd);

            //Store data from old session
            HttpApplication ctx = System.Web.HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
            FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;

            SessionStateStoreData rqItem = null;
            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;

                if ((field.Name.Equals("_rqItem")))
                {
                    rqItem = (SessionStateStoreData)field.GetValue(ssm);
                }
            }
            object lockId = rqLockIdField.GetValue(ssm);

            if ((lockId != null) && (oldId != null))
            {
                store.RemoveItem(System.Web.HttpContext.Current, oldId, lockId, rqItem);
            }

            rqStateNotFoundField.SetValue(ssm, true);
            rqIdField.SetValue(ssm, newId);
        }
    }
}