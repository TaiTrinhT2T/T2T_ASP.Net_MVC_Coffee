using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.EF;
using MySite.Areas.Data_Access.Dao;

namespace MySite.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDao dao = new EmployeeDao();
        // GET: Admin/Employee
        public ActionResult Index()
        {
            // IQueryable<Office> Offices = dao.Offices;
            IQueryable<Employee> p = dao.ListEmployee();
           return View("Index", p);
        }

        public ActionResult Detail(int id)
        {
            Employee e = dao.FindEmployee(id);

            return View("Detail", e);
        }

        public ActionResult Create()
        {
            ResponsibiltyDao cDao = new ResponsibiltyDao();
            IQueryable<Responsibilty> listResponsibilty = cDao.ListResponsibilty();
            ViewBag.Responsibilty = listResponsibilty;
            return View();
        }

        public ActionResult AddAction(Employee p, string role)
        {
            EmployeeDao pDao = new EmployeeDao();
            pDao.InsertEmployee(role, p.Name, p.Email, p.Telephone, p.Status, p.Password);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee e = dao.FindEmployee(id);

            ResponsibiltyDao cDao = new ResponsibiltyDao();
            IQueryable<Responsibilty> listResponsibilty = cDao.ListResponsibilty();
            ViewBag.Responsibilty = listResponsibilty;

            return View(e);
        }

        public ActionResult EditAction(Employee p, string role)
        {
            EmployeeDao pDao = new EmployeeDao();
            pDao.UpdateEmployee(p.ID_Employee, role, p.Name, p.Email, p.Telephone, p.Status, p.Password);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}