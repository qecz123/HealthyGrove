using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthyGrove.Models;

namespace HealthyGrove.Controllers
{
    public class InvasivesController : Controller
    {
        private HealthyGrove_ModelContainer db = new HealthyGrove_ModelContainer();

        public ActionResult RemoveWeed()
        {
            return View();
        }

        public ActionResult Disposal()
        {
            return View();
        }

        public ActionResult Collection()
        {
            return View();
        }

        // GET: Invasives
        public ActionResult Index()
        {
            return View(db.InvasiveSet.OrderBy(x => x.ScientificName).ToList());
        }

        // GET: Invasives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invasive invasive = db.InvasiveSet.Find(id);
            if (invasive == null)
            {
                return HttpNotFound();
            }
            return View(invasive);
        }

        public void Save(int id)
        {
            if (Session["InvasivesCollection"] == null)
            {
                List<Invasive> collection = new List<Invasive>();
                collection.Add(db.InvasiveSet.Find(id));
                Session["InvasivesCollection"] = collection;
            }
            else
            {
                List<Invasive> collection = (List<Invasive>)Session["InvasivesCollection"];
                int index = isExist(id);
                if (index != -1)
                {
                    
                }
                else
                {
                    collection.Add(db.InvasiveSet.Find(id));
                }
                Session["InvasivesCollection"] = collection;
            }
            //return PartialView("_partialPlant", result);
            //return Json(new { stringContent = "Your String content here!"});
        }

        public void Remove(int id)
        {
            List<Invasive> collection = (List<Invasive>)Session["InvasivesCollection"];
            int index = isExist(id);
            collection.RemoveAt(index);
            Session["InvasivesCollection"] = collection;
        }

        private int isExist(int id)
        {
            List<Invasive> collection = (List<Invasive>)Session["InvasivesCollection"];
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].InvasiveId.Equals(id))
                    return i;
            return -1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
