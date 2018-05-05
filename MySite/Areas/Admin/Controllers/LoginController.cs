using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.Dao;

namespace MySite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            EmployeeDao emDao = new EmployeeDao();
            int feedBack = emDao.CheckLogin(userName, password);
            if (feedBack == 1)
            {

                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            //else if (feedBack == 2)
            //{
                
            //    return RedirectToAction("HomePage", "HomePage"); // Chức năng này chưa làm
            //}
            else
            {
                ModelState.AddModelError("loitaikhoan", "Tài khoản hoặc mật khẩu không chính xác");
            }
            return View("Index");
        }
    }
}