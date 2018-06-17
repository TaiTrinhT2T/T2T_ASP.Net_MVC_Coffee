using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using MySite.Areas.Data_Access.Dao;
using MySite.Areas.Data_Access.EF;
using System.Web.Script.Serialization;

namespace MySite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private const string CartSession = "cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<HangHoaBan>();
            if (cart != null)
            {
                list = (List<HangHoaBan>)cart;
                ViewBag.CountItemsInCart = list.Count;
            }
            return View(list);
        }

        public ActionResult AddItem(int id, int quantity)
        {
            var _product = new ProductDao().FindProduct(id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<HangHoaBan>) cart;
                if (list.Exists(x => x.product.ID_Product == id))
                {
                    foreach (var item in list)
                    {
                        if (item.product.ID_Product == id)
                        {
                            item.sl += quantity;
                        }
                    }
                }
                else
                {
                    // Tao moi doi tuong HangHoaBan
                    var item = new HangHoaBan();
                    item.product = _product;
                    item.sl = quantity;
                    list.Add(item);
                }
                //Gan van session
                Session[CartSession] = list;
            }
            else
            {
                // Tao moi doi tuong HangHoaBan
                var item = new HangHoaBan();
                item.product = _product;
                item.sl = quantity;
                var list = new List<HangHoaBan>();
                list.Add(item);
                //Gan van session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteItem(long id)
        {
            var sessionCart = (List<HangHoaBan>)Session[CartSession];
            sessionCart.RemoveAll(x => x.product.ID_Product == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<HangHoaBan>>(cartModel);
            var sessionCart = (List<HangHoaBan>) Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.ID_Product == item.product.ID_Product);
                if (jsonItem != null)
                {
                    item.sl = jsonItem.sl;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<HangHoaBan>();
            if (cart != null)
            {
                list = (List<HangHoaBan>)cart;
                ViewBag.CountItemsInCart = list.Count;
            }
            return View(list);
        }

        public ActionResult PaymentAction(string Name, string Address, string Email, string Telephone)
        {
            BillDao dao = new BillDao();
            var date = DateTime.Now;
            var cart = (List<HangHoaBan>) Session[CartSession];
            int total = 0;
            foreach (var item in cart)
            {
                total += (int)item.sl * (int)item.product.Price;
            }
            foreach (var item in cart)
            {
                dao.InsertBill(item.product.ID_Product, 3, date, total, item.sl, Name, Address, Email, Telephone);
            }
            Session[CartSession] = null;
            return View("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}