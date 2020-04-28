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
