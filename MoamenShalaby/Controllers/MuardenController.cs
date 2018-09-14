using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoamenShalaby.Models;
namespace MoamenShalaby.Controllers
{
    public class MuardenController : Controller
    {
        // GET: customer
        quntra_project db = new quntra_project();
        public ActionResult Index()
        {

            return View(db.Muardens);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create (MuardenViewModel obj)
        {
            Muarden cms = new Muarden();
            cms.name = obj.name;
            cms.notes = obj.notes;
            cms.date = DateTime.Now;
            db.Muardens.Add(cms);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edite (int id)
        {
            var row = db.Muardens.Find(id);


            return View(row);
        }
        [HttpPost]
        public ActionResult Edite (MuardenViewModel obj)
        {
            var row = db.Muardens.Find(obj.id);
            row.id = obj.id;
            row.name = obj.name;
            row.notes = obj.notes;
            row.date = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       public ActionResult Delete (int id)
        {
            var row = db.Muardens.Find(id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete (Muarden obj)
        {
            var row = db.Muardens.Find(obj.id);

            db.Trans_Muarden.RemoveRange(db.Trans_Muarden.Where(a => a.muarden_id == row.id));

            db.Muardens.Remove(row);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}