using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;

namespace MoamenShalaby.Controllers
{
    public class transactionController : Controller
    {
        // GET: transaction



        quntra_project db = new quntra_project();
        public ActionResult Index()
        {
            return View(db.transactions.ToList());
        }
        [HttpGet]
        public ActionResult Create ()
        {
            ViewBag.name = new SelectList(db.products,"id","name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(TransactionViewModel obj)
        {
            
            var data = db.products.Find(obj.Products_id);
            if (data.orginal_Qty > obj.saled_Qty)
            {

                if (obj.check == true)
                {
                    transaction x = new transaction();


                    x.saled_Qty = obj.saled_Qty * 12;
                    x.saled_Price = (decimal)obj.saled_Price;
                    x.Products_id = obj.Products_id;
                    x.total_price = (obj.saled_Qty * 12) * ((decimal)obj.saled_Price);
                    x.date = DateTime.Now.ToString();
                    db.transactions.Add(x);
                    db.SaveChanges();



                    return RedirectToAction("Index");
                }
                else
                {
                    transaction x = new transaction();


                    x.saled_Qty = obj.saled_Qty;
                    x.saled_Price = (decimal)obj.saled_Price;
                    x.Products_id = obj.Products_id;
                    x.total_price = (obj.saled_Qty) *((decimal)obj.saled_Price);
                    x.date = DateTime.Now.ToString();
                    db.transactions.Add(x);
                    db.SaveChanges();



                    return RedirectToAction("Index");

                }
            }
            else
            {
                
                ViewBag.name = new SelectList(db.products, "id", "name");
                ViewBag.message = "هذا الصنف به عجز  ";
                
                return View();
                
            }
            
        }

        [HttpGet]
        public ActionResult Edite(int id)
        {

           

            return View(db.transactions.Find(id));
        }
        [ActionName("Delete")]
        public ActionResult ConfirmDelete()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            var row = db.transactions.Find(id);
            db.transactions.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}