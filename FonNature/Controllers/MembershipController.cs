using FonNature.Filter;
using FonNature.Services;
using FonNature.Services.Extension;
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
        private readonly IServiceRepository _serviceRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IClientAccountRepository _clientAccountRepository;
        public MembershipController(IMembershipService membershipService, IClientAccountRepository accountRepository, IProductAdminRepository productRepository, IOrderRepository orderRepository, IServiceRepository serviceRepository, IBookingRepository bookingRepository, IClientAccountRepository clientAccountRepository)
        {
            _membershipService = membershipService;
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _serviceRepository = serviceRepository;
            _bookingRepository = bookingRepository;
            _clientAccountRepository = clientAccountRepository;
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

            if(!accountInformation.IsConfirm)
            {
                return Json(new
                {
                    status = false,
                    message = "Account is not activated, please check your email for active!"
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
            ViewBag.Services = _serviceRepository.GetServices();
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
            ViewBag.Services = _serviceRepository.GetServices();
            ViewBag.OrderInfors = _orderRepository.GetOrderInfors();
            return View(result);
        }

        public ActionResult CancelBooking(long id)
        {
            _bookingRepository.CancelBooking(id);
            return Redirect("/membership/myprofile#bookings");
        }

        [HttpPost]
        public JsonResult IsExistMobilePhone(string mobilePhone)
        {
            if(string.IsNullOrWhiteSpace(mobilePhone))
            {
                return Json(new { isError = true, message = "mobilePhone is null!" });
            }

            var mobilePhoneWithoutAreaCode = mobilePhone.RemoveAreaCode();
            if (string.IsNullOrWhiteSpace(mobilePhoneWithoutAreaCode))
            {
                return Json(new { isError = true, message = "System error!" });
            }

            var isExist = _clientAccountRepository.IsExistMobilePhone(mobilePhone);

            return Json(new { isExist = isExist, isError = false });
        }

        [HttpPost]
        public JsonResult IsExistEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Json(new { isError = true, message = "mobilePhone is null!" });
            }

            var isExist = _clientAccountRepository.IsExistEmail(email);

            return Json(new { isExist = isExist, isError = false });
        }

        [HttpPost]
        public JsonResult RegisterAccount(string email, string mobilePhone, string password, string lastName, string firstName)
        {
            var result = _membershipService.Register(firstName,lastName,email,mobilePhone,password);

            return Json(new { result = result, isError = false });
        }

        public ActionResult Confirm(string token, string email)
        {
            var account = _clientAccountRepository.ConfirmAccountByTokenAndEmail(email, token);
           
            if (account == null)
            {
                return Redirect("/");
            }

            return Redirect("/Success/RegisterSuccess?email=" + email);
        }
    }
}