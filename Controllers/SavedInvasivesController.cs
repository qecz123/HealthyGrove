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
    public class SavedInvasivesController : Controller
    {
        private HealthyGrove_ModelContainer db = new HealthyGrove_ModelContainer();

        // GET: SavedInvasives
        public ActionResult Index()
        {
            var savedInvasiveSet = db.SavedInvasiveSet.Include(s => s.Invasive);
            return View(savedInvasiveSet.ToList());
        }

        // GET: SavedInvasives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedInvasive savedInvasive = db.SavedInvasiveSet.Find(id);
            if (savedInvasive == null)
            {
                return HttpNotFound();
            }
            return View(savedInvasive);
        }

        // GET: SavedInvasives/Create
        public ActionResult Create()
        {
            ViewBag.InvasiveId = new SelectList(db.InvasiveSet, "InvasiveId", "ScientificName");
            return View();
        }

        // POST: SavedInvasives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavedInvasiveId,UserId,InvasiveId")] SavedInvasive savedInvasive)
        {
            if (ModelState.IsValid)
            {
                db.SavedInvasiveSet.Add(savedInvasive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvasiveId = new SelectList(db.InvasiveSet, "InvasiveId", "ScientificName", savedInvasive.InvasiveId);
            return View(savedInvasive);
        }

        // GET: SavedInvasives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedInvasive savedInvasive = db.SavedInvasiveSet.Find(id);
            if (savedInvasive == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvasiveId = new SelectList(db.InvasiveSet, "InvasiveId", "ScientificName", savedInvasive.InvasiveId);
            return View(savedInvasive);
        }

        // POST: SavedInvasives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavedInvasiveId,UserId,InvasiveId")] SavedInvasive savedInvasive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savedInvasive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvasiveId = new SelectList(db.InvasiveSet, "InvasiveId", "ScientificName", savedInvasive.InvasiveId);
            return View(savedInvasive);
        }

        // GET: SavedInvasives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedInvasive savedInvasive = db.SavedInvasiveSet.Find(id);
            if (savedInvasive == null)
            {
                return HttpNotFound();
            }
            return View(savedInvasive);
        }

        // POST: SavedInvasives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavedInvasive savedInvasive = db.SavedInvasiveSet.Find(id);
            db.SavedInvasiveSet.Remove(savedInvasive);
            db.SaveChanges();
            return RedirectToAction("Index");
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
