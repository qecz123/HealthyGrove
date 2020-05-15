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
    public class NonInvasivesController : Controller
    {
        private HealthyGrove_ModelContainer db = new HealthyGrove_ModelContainer();

        // GET: NonInvasives
        public ActionResult Index()
        {
            return View(db.NonInvasiveSet.OrderBy(x => x.ScientificName).ToList());
        }

        // GET: NonInvasives/Planner
        public ActionResult Planner()
        {
            return View();
        }

        // GET: NonInvasives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonInvasive nonInvasive = db.NonInvasiveSet.Find(id);
            if (nonInvasive == null)
            {
                return HttpNotFound();
            }
            return View(nonInvasive);
        }

        public void Save(int id)
        {
            if (Session["nonInvasivesCollection"] == null)
            {
                List<NonInvasive> collection = new List<NonInvasive>();
                collection.Add(db.NonInvasiveSet.Find(id));
                Session["nonInvasivesCollection"] = collection;
            }
            else
            {
                List<NonInvasive> collection = (List<NonInvasive>)Session["nonInvasivesCollection"];
                int index = isExist(id);
                if (index != -1)
                {
                    
                }
                else
                {
                    collection.Add(db.NonInvasiveSet.Find(id));
                }
                Session["nonInvasivesCollection"] = collection;
            }
            //return PartialView("_partialPlant", result);
            //return Json(new { stringContent = "Your String content here!"});
        }

        public void Remove(int id)
        {
            List<NonInvasive> collection = (List<NonInvasive>)Session["nonInvasivesCollection"];
            int index = isExist(id);
            collection.RemoveAt(index);
            Session["nonInvasivesCollection"] = collection;
        }

        private int isExist(int id)
        {
            List<NonInvasive> collection = (List<NonInvasive>)Session["nonInvasivesCollection"];
            for (int i = 0; i < collection.Count; i++)
                if (collection[i].NonInvasiveId.Equals(id))
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
