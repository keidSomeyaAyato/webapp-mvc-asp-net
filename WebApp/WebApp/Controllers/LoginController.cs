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
                string userIPAddress = "127.0.0.1";

                //DB確認
                //_userService.MST_USERCheck();

                // ログイン処理
                bool isLoginSuccessful = _userService.Login(LoginID, LoginPassword, userIPAddress);

                if (isLoginSuccessful)
                {
                    // ログイン成功時の処理（例: ホームページへリダイレクト）
                    return RedirectToAction("Home", "Dashboard");
                }
                else
                {
                    // ログイン失敗時の処理
                    return View(model);
                }
            }
            else
            {
                //異常あり
                return View(model);
            }

            
        }
    }
}