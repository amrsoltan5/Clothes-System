using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class testController : Controller
    {
        // GET: test
        quntra_project db = new quntra_project();
        public ActionResult Index()
        {
            return View(db.products);
        }

        [HttpGet]
        public ActionResult Create()

        {


            return View();
        }
        [HttpPost]
        public ActionResult Create (ProductsViewModel obj)

        {
            if (obj.dasta == false)
            {
                product pro = new product();
                pro.name = obj.name;
                pro.orginal_Qty = obj.orginal_Qty;

                pro.orginal_price = obj.orginal_price;
                pro.total = obj.orginal_Qty * obj.orginal_price;
                pro.date = DateTime.Now.ToString();
                db.products.Add(pro);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                product pro = new product();
                pro.name = obj.name;
                pro.orginal_Qty = obj.orginal_Qty*12;

                pro.orginal_price = obj.orginal_price;
                pro.total = obj.orginal_Qty * obj.orginal_price;
                pro.date = DateTime.Now.ToString();
                db.products.Add(pro);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
        }
        [HttpGet]

      public ActionResult Edite (int id)
        {
            var row = db.products.Find(id);

            return View(row);

        }
        [HttpPost]
        public ActionResult Edite(ProductsViewModel x)
        {
            var row = db.products.Find(x.id);

            row.id = x.id;
            row.name = x.name;
            row.orginal_Qty = x.orginal_Qty;
            row.orginal_price = x.orginal_price;
            row.total = x.orginal_Qty * x.orginal_price;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
           var data = db.products.Find(id);

            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(product a)
        {
           
           
            var row = db.products.Find(a.id);
          db.transactions.RemoveRange( db.transactions.Where(e => e.Products_id == row.id));
            
            db.products.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


       
        public ActionResult Search()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Search (DateTime x)
        {
          //  var collection = db.products.Where(a => a.date == x);
            return View();
        }
    }
}