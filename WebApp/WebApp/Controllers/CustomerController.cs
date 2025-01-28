using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MST_USERService _userService = new MST_USERService();

        // GET: Customer
        public ActionResult List()
        {
            // ※２．ログイン済みのチェック
            if (Session["USER_CD"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //遷移の確認
            if (TempData["From"] != null)
            {
                string from = TempData["From"].ToString();
                TempData["From"] = from; //再度登録してリロードできるように
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


            ViewBag.Title = "顧客一覧";
            ViewBag.Name = _userService.GetName(Session["USER_CD"].ToString());
            
            return View("CustomerList");
        }
    }
}