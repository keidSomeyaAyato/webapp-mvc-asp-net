using System;
using System.Collections.Generic;
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
            ViewBag.Title = "タイトルテスト";
            ViewBag.Name = "名前テスト";
            return View("CustomerList");
        }
    }
}