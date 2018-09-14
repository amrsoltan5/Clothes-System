using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        quntra_project db = new quntra_project();
        [HttpGet]
        
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel obj)
        {

            var row = db.users.Any(a => a.username == obj.username && a.password == obj.password);

            if (row == true)
            {
                return RedirectToAction("Index", "test");
            }
            else
            {
                ViewBag.message = "برجاء ادخال اسم مستخدم وكلمه سر صحيحه ";

                return View();
            }
        }

    }
}