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
            ViewBag.Visitor = new IPAddressRepository().CountVisitor();

            ViewBag.CountVisitor = new IPAddressRepository().CountByMonth(DateTime.Now.Month);
            ViewBag.CountVisitor1 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountVisitor2 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountVisitor3 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountVisitor4 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountVisitor5 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountVisitor6 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountVisitor7 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountVisitor8 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-8).Month);
            return View();
        }
    }
}