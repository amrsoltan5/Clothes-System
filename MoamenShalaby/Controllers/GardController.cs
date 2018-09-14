using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class GardController : Controller
    {
        // GET: Gard
        quntra_project db = new quntra_project();

        public ActionResult Index()
        {

            return View(db.Gards);
        }
        [HttpGet]
        public ActionResult Create ()
        {
            ViewBag.name = new SelectList(db.products, "id", "name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(GardViewModel obj)
        {
            var Qty = db.products.Find(obj.product_id);
            var Saled_Qty = db.transactions.Where(a => a.Products_id == obj.product_id).Select(a => a.saled_Qty).Sum();
            
            Gard gar = new Gard();
            gar.product_id = obj.product_id;
            gar.Qty_ava = Qty.orginal_Qty - Saled_Qty;
            gar.date = DateTime.Now;
            db.Gards.Add(gar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}