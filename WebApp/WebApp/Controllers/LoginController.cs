using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Login;
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
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
            //lll
            Debug.WriteLine(model.LoginID);
            Debug.WriteLine(model.Password);
            return View();
        }
    }
}