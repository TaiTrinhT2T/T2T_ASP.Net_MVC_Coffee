﻿using System;
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
    public class ProductsController : Controller
    {
        ProductDao dao = new ProductDao();

        // GET: Admin/Employee

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = dao.ListAllPaging(page, pageSize);
            // IQueryable<Office> Offices = dao.Offices;
            //IQueryable<Employee> p = dao.ListEmployee();
            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            Product e = dao.FindProduct(id);
            //Product listResponsibilty = e;
            ViewBag.DetailUrlImageProduct = e;
            return View("Details", e);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddAction(Product p)
        {
            dao.InsertProduct(p.Name, p.Detail, p.Price, p.Image);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Product e = dao.FindProduct(id);
            //Product listResponsibilty = e;
            ViewBag.EditUrlImageProduct = e;
            return View(e);
        }

        public ActionResult EditAction(Product p)
        {
            dao.UpdateProduct(p.ID_Product, p.Name, p.Detail, p.Price, p.Image);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dao.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
