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
