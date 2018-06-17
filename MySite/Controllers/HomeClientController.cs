using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.Dao;
using MySite.Areas.Data_Access.EF;

namespace MySite.Controllers
{
    public class HomeClientController : Controller
    {
        private const string CartSession = "cart";

        ProductDao dao = new ProductDao();

        // GET: Admin/Employee

        public ActionResult Index()
        {
            var model = dao.ListAllPaging(1, 9);
            // IQueryable<Office> Offices = dao.Offices;
            //IQueryable<Employee> p = dao.ListEmployee();
            return View("Index", model);
        }

        public ActionResult View(int id)
        {
            Product e = dao.FindProduct(id);
            //Product listResponsibilty = e;
            ViewBag.DetailUrlImageProduct = e;
            return View("View", e);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<HangHoaBan>();
            if (cart != null)
            {
                list = (List<HangHoaBan>)cart;
            }
            return PartialView(list);
        }
    }
}