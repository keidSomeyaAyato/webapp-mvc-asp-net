using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Login;
using WebApp.Services;
using System.Diagnostics;
using System.EnterpriseServices;
using Microsoft.Identity.Client;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly MST_USERService _userService = new MST_USERService();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            string userIp = Request.UserHostAddress; // ユーザーのIPアドレスを取得
            ViewBag.UserIP = userIp; // ビューにIPを渡す

            return View();
        }

        // POST : Login
        [HttpPost]
        public ActionResult Index(FormLoginModel model)
        {
            if(ModelState.IsValid)
            {
                //formから入力内容を取得
                string LoginID = model.LoginID; //USER_CD
                string LoginPassword = model.Password;
                string UserIPAddress = model.IpAddress;

                //DB確認
                //_userService.MST_USERCheck();

                // ログイン処理
                bool isUserCheck = _userService.UserCheck(LoginID);

                if (isUserCheck)
                {
                    bool isPassword = _userService.PasswordCheck(LoginID, LoginPassword);

                    if (isPassword)
                    {
                        _userService.UpdateLastLoginTimeAndIp(LoginID, UserIPAddress);

                        //ユーザCDをセッションに保存
                        Session["USER_CD"] = LoginID;

                        // ログイン成功時の処理（例:顧客一覧）
                        return RedirectToAction("Index", "CustomerList");
                    }
                }

                return View(new { errorMessage = "ログインIDまたはパスワードが間違っています。" });
            }
            else
            {
                //異常あり
                return View(model);
            }
        }
    }
}