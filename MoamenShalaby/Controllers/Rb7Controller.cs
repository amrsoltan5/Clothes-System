using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class Rb7Controller : Controller
    {
        // GET: Rb7
        quntra_project db = new quntra_project();

        public ActionResult Index()
        {

            return View(db.rb7);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.date = DateTime.Now;

            return View();
        }
        [HttpPost]

        public ActionResult Create(Rb7ViewModel obj)
        {
            var day = obj.day; var month = obj.month; var year = obj.year;
            var date = year + "-" + month + "-" + day;
            var Price_m5zan = db.products.Where(a =>a.date.ToString().Contains(date)).Select(a => a.total).Sum();

            var Price_Saled = db.transactions.Where(a => a.date.Contains(date)).Select(a => a.saled_Price).Sum();

       


            rb7 c = new rb7();

            c.date = DateTime.Now;
            c.Price_Total = Price_m5zan;
            c.Qty_Total_Saled = Price_Saled;
            c.rb71 = Price_Saled - Price_m5zan;
            db.rb7.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}