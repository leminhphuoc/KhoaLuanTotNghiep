using FonNature.Filter;
using Models.Repository;
using System;
using System.Web.Mvc;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class HomeAdminController : Controller
    {
       
        //GET: Admin/HomeAdmin
        public ActionResult HomeAdmin()
        {
            ViewBag.Visitor = IPAddressRepository.getInstance().CountVisitor();
            ViewBag.Customer = CustomerAdminRepository.getInstance().Count();

           
            ViewBag.CountCustomer = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.Month);
            ViewBag.CountCustomer1 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountCustomer2 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountCustomer3 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountCustomer4 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountCustomer5 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountCustomer6 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountCustomer7 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountCustomer8 = CustomerAdminRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-8).Month);

            ViewBag.CountVisitor = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.Month);
            ViewBag.CountVisitor1 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountVisitor2 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountVisitor3 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountVisitor4 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountVisitor5 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountVisitor6 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountVisitor7 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountVisitor8 = IPAddressRepository.getInstance().CountByMonth(DateTime.Now.AddMonths(-8).Month);
            return View();
        }
    }
}