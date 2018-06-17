using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.Dao;

namespace MySite.Areas.Admin.Controllers
{
    public class BillsController : Controller
    {
        BillDao dao = new BillDao();
        // GET: Admin/Bills
        public ActionResult Index()
        {
            var model = dao.ListBillAll();
            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            var model = dao.ListBillDetails(id);

            return View("Details", model);
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteBill(id);
            return RedirectToAction("Index");
        }
    }
}