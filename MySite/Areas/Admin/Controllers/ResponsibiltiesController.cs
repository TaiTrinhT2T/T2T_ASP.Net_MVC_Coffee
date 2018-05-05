using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.Dao;
using MySite.Areas.Data_Access.EF;

namespace MySite.Areas.Admin.Controllers
{
    public class ResponsibiltiesController : Controller
    {
        ResponsibiltyDao dao = new ResponsibiltyDao();

        // GET: Admin/Employee
        public ActionResult Index()
        {
            IQueryable<Responsibilty> p = dao.ListResponsibilty();
            return View("Index", p);
        }

        public ActionResult Details(int id)
        {
            Responsibilty e = dao.FindResponsibilty(id);

            return View("Details", e);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddAction(Responsibilty p)
        {
            dao.InsertResponsibilty(p.Name, p.Description);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Responsibilty e = dao.FindResponsibilty(id);

            return View(e);
        }

        public ActionResult EditAction(Responsibilty p)
        {
            dao.UpdateResponsibilty(p.ID_Res, p.Name, p.Description);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteResponsibilty(id);
            return RedirectToAction("Index");
        }
    }
}
