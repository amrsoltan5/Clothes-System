using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class Trans_CustomerController : Controller
    {
        // GET: Trans_Customer
        quntra_project db = new quntra_project();

        public ActionResult Index()
        {
            return View(db.Trans_Customer);
        }

        public ActionResult Create ()
        {
            ViewBag.name = new SelectList(db.customers, "id", "name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Trans_CustomerViewModel obj)
        {

            Trans_Customer c = new Trans_Customer();
            c.customer_id = obj.customer_id;
            c.total = obj.total;
            c.cash = obj.cash;
            c.reminder = obj.total - obj.cash;
            c.notes = obj.notes;
            c.date = DateTime.Now;
            db.Trans_Customer.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edite(int id)
        {
            var data = db.Trans_Customer.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edite(Trans_CustomerViewModel obj)
        {
            var row = db.Trans_Customer.Find(obj.id);

            
            row.total = obj.total;
            row.cash = obj.cash;
            row.reminder = obj.total - obj.cash;
            row.notes = obj.notes;

            row.date = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Trans_Customer.Find(id);

            return View(data);
        }

        [HttpPost]

        public ActionResult Delete(Trans_Customer obj)
        {
            var row = db.Trans_Customer.Find(obj.id);

            db.Trans_Customer.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}