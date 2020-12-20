using FonNature.Filter;
using FonNature.Services;
using Models.Entity;
using Models.Model;
using Models.Repository;
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
        private readonly IClientAccountRepository _accountRepository;
        private readonly IProductAdminRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public MembershipController(IMembershipService membershipService, IClientAccountRepository accountRepository, IProductAdminRepository productRepository, IOrderRepository orderRepository)
        {
            _membershipService = membershipService;
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
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

        [AuthenticationClient]
        public ActionResult MyProfile()
        {
            var account = Session[Constant.Membership.AccountSession] as ClientAccount;
            if(account == null)
            {
                return Redirect("/");
            }

            var result = _membershipService.GetMemberProfileViewModel(account.Id);
            TempData["orders"] = result.Orders;
            ViewBag.Products = _productRepository.GetListProduct();
            ViewBag.OrderInfors = _orderRepository.GetOrderInfors();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthenticationClient]
        public ActionResult MyProfile(ClientAccount clientAccount, string currentPwd, string newPwd, string confirmPwd)
        {
            var currentAccount = Session[Constant.Membership.AccountSession] as ClientAccount;
            if(currentAccount == null)
            {
                return Redirect("/");
            }

            if (!string.IsNullOrWhiteSpace(currentPwd) && currentPwd.Equals(currentAccount.PassWord))
            {
                if(!string.IsNullOrWhiteSpace(newPwd) && !string.IsNullOrWhiteSpace(confirmPwd) && newPwd.Equals(confirmPwd))
                {
                    var isUpdateSuccess = _accountRepository.UpdateProfile(currentAccount.Id, newPwd, clientAccount.FirstName, clientAccount.LastName);
                    if(isUpdateSuccess)
                    {
                        return RedirectToAction("MyProfile");
                    }

                    ModelState.AddModelError("", "Update password fail, please contact admin for more detail!");
                }
                else
                {
                    ModelState.AddModelError("", "Your confirmation password does not match the new password!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Current Password is incorrect!");
            }
            var orders = TempData["orders"] as List<Order>;
            var result = new MemberProfileViewModel()
            {
                Orders = orders,
                AccountInformation = clientAccount
            };
            ModelState["PassWord"].Errors.Clear();
            ViewBag.Products = _productRepository.GetListProduct();
            ViewBag.OrderInfors = _orderRepository.GetOrderInfors();
            return View(result);
        }
    }
}