using FonNature.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("membership")]
    [Route("{action=Index}")]
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;
        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            var accountInformation = _membershipService.Login(email, password);
            if (accountInformation == null)
            {
                return Json(new
                {
                    status = false,
                    message = "Incorrect login information!"
                }
                );
            }
            Session[Constant.Membership.IsLoginSession] = true;
            Session[Constant.Membership.AccountSession] = accountInformation;
            return Json(new
            {
                status = true,
                message = "Success!",
                account = accountInformation
            }
            );
        }

        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session[Constant.Membership.IsLoginSession] = false;
            Session[Constant.Membership.AccountSession] = null;
            var currentUrl = HttpContext.Request.UrlReferrer.ToString();
            return Redirect(currentUrl);
        }
    }
}