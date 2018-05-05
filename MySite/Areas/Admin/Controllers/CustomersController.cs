using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.EF;
using MySite.Areas.Data_Access.Dao;

namespace MySite.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        CustomerDao dao = new CustomerDao();

        // GET: Admin/Employee
        public ActionResult Index()
        {
            IQueryable<Customer> p = dao.ListCustomer();
            return View("Index", p);
        }

        public ActionResult Details(int id)
        {
            Customer e = dao.FindCustomer(id);

            return View("Details", e);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddAction(Customer p)
        {
            dao.InsertCustomer(p.Name, p.Address, p.Email, p.Telephone);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Customer e = dao.FindCustomer(id);

            return View(e);
        }

        public ActionResult EditAction(Customer p)
        {
            dao.UpdateCustomer(p.ID_Customer, p.Name, p.Address, p.Email, p.Telephone);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
