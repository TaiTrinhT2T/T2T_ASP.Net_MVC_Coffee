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
    public class RolesController : Controller
    {
        RoleDao dao = new RoleDao();

        // GET: Admin/Employee
        public ActionResult Index()
        {
            IQueryable<Role> p = dao.ListRole();
            return View("Index", p);
        }

        public ActionResult Details(int id)
        {
            Role e = dao.FindRole(id);

            return View("Details", e);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddAction(Role p)
        {
            dao.InsertRole(p.Name_Role);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Role e = dao.FindRole(id);

            return View(e);
        }

        public ActionResult EditAction(Role p)
        {
            dao.UpdateRole(p.ID_Role, p.Name_Role);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteRole(id);
            return RedirectToAction("Index");
        }
    }
}
