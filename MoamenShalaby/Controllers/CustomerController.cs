using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;

namespace MoamenShalaby.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        quntra_project db = new quntra_project();

        public ActionResult Index()
        {

            return View(db.customers);
        }
        [HttpGet]
        public ActionResult Create ()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create (CustomerViewModel obj)
        {
            customer cms = new customer();
            cms.name = obj.name;
            cms.notes = obj.notes;
            cms.date = DateTime.Now;
            db.customers.Add(cms);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edite (int id)
        {
            var data = db.customers.Find(id);

            return View(data);
        }
        [HttpPost]
        public ActionResult Edite (CustomerViewModel obj)
        {
            var row = db.customers.Find(obj.id);
            row.name = obj.name;
            row.notes = obj.notes;
            row.date = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete (int id)
        {

            var row = db.customers.Find(id);

            return View(row);
        }

        public ActionResult Delete (customer obj)
        {
            var row = db.customers.Find(obj.id);
            db.Trans_Customer.RemoveRange(db.Trans_Customer.Where(a => a.customer_id == obj.id));

            db.customers.Remove(row);
            db.SaveChanges();


            return RedirectToAction("Index");
        }


    }

}