using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {
            if (TempData["From"] != null)
            {
                string from = TempData["From"].ToString();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Title = "タイトルテスト";
            ViewBag.Name = "名前テスト";
            return View("CustomerList");
        }
    }
}