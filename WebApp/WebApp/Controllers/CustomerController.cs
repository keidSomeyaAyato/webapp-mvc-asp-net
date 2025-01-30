using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MST_USERService _userService = new MST_USERService();

        // GET: Customer
        public ActionResult List()
        {
            //vb宣言
            string vbCondCustomerIdFrom = "";
            string vbCondCustomerIdTo = "";
            int vbCustomerType = 4;
            string vbKeyWord = "";
            string from;

            // ※２．ログイン済みのチェック
            if (Session["USER_CD"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //遷移の確認
            if (TempData["From"] != null)
            {
                from = TempData["From"].ToString();
                TempData["From"] = from; //再度登録してリロードできるように
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            //モード別の処理
            switch (from)
            {
                case "LOGIN":
                    vbCondCustomerIdFrom = "";
                    vbCondCustomerIdTo = "";
                    vbCustomerType = 4;
                    vbKeyWord = "";
                    break;
                case "INPUT":
                case "CONFIRM":
                    break;
                case "DELETE":
                    break;
                default:
                    break;
            }
            //Form初期表示
            ViewBag.Title = "顧客一覧";
            ViewBag.Name = _userService.GetName(Session["USER_CD"].ToString());
            ViewBag.CondCustomerIdFrom = vbCondCustomerIdFrom;
            ViewBag.CondCustomerIdTo = vbCondCustomerIdTo;
            ViewBag.CustomerType = vbCustomerType;
            ViewBag.KeyWord = vbKeyWord;

            return View("CustomerList");
        }
    }
}