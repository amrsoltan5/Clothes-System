using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class Trans_MuardenController : Controller
    {
        // GET: Madeen
        quntra_project db = new quntra_project();
        public ActionResult Index()
        {

            return View(db.Trans_Muarden);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            ViewBag.Muarden = new SelectList(db.Muardens, "id", "name");

            return View();
        }

        [HttpPost]
        public ActionResult Create (Trans_MuardenViewModel obj)
        {
            Trans_Muarden mad = new Trans_Muarden();

            mad.muarden_id = obj.muarden_id;
            mad.Total = obj.Total;
            mad.Cash = obj.Cash;
            mad.Reminder = obj.Total-obj.Cash;
            mad.Notes = obj.Notes;
            mad.date = DateTime.Now;
            db.Trans_Muarden.Add(mad);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult Edite(int id)
        {
            

            var row = db.Trans_Muarden.Find(id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edite(Trans_MuardenViewModel obj)
        {
            var row = db.Trans_Muarden.Find(obj.id);

            row.id = obj.id;
            
            row.Total = obj.Total;
            row.Cash = obj.Cash;
            row.Reminder = obj.Total - obj.Cash;
            row.Notes = obj.Notes;
            row.date = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete (int id)
        {
            var data = db.Trans_Muarden.Find(id);

            return View(data);
        }

        [HttpPost]

        public ActionResult Delete(Trans_Muarden obj)
        {
            var row = db.Trans_Muarden.Find(obj.id);

            db.Trans_Muarden.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}