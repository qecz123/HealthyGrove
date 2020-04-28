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
    public class SavedNonInvasivesController : Controller
    {
        private HealthyGrove_ModelContainer db = new HealthyGrove_ModelContainer();

        // GET: SavedNonInvasives
        public ActionResult Index()
        {
            var savedNonInvasiveSet = db.SavedNonInvasiveSet.Include(s => s.NonInvasive);
            return View(savedNonInvasiveSet.ToList());
        }

        // GET: SavedNonInvasives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedNonInvasive savedNonInvasive = db.SavedNonInvasiveSet.Find(id);
            if (savedNonInvasive == null)
            {
                return HttpNotFound();
            }
            return View(savedNonInvasive);
        }

        // GET: SavedNonInvasives/Create
        public ActionResult Create()
        {
            ViewBag.NonInvasiveId = new SelectList(db.NonInvasiveSet, "NonInvasiveId", "ScientificName");
            return View();
        }

        // POST: SavedNonInvasives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavedNonInvasiveId,UserId,NonInvasiveId")] SavedNonInvasive savedNonInvasive)
        {
            if (ModelState.IsValid)
            {
                db.SavedNonInvasiveSet.Add(savedNonInvasive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NonInvasiveId = new SelectList(db.NonInvasiveSet, "NonInvasiveId", "ScientificName", savedNonInvasive.NonInvasiveId);
            return View(savedNonInvasive);
        }

        // GET: SavedNonInvasives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedNonInvasive savedNonInvasive = db.SavedNonInvasiveSet.Find(id);
            if (savedNonInvasive == null)
            {
                return HttpNotFound();
            }
            ViewBag.NonInvasiveId = new SelectList(db.NonInvasiveSet, "NonInvasiveId", "ScientificName", savedNonInvasive.NonInvasiveId);
            return View(savedNonInvasive);
        }

        // POST: SavedNonInvasives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavedNonInvasiveId,UserId,NonInvasiveId")] SavedNonInvasive savedNonInvasive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savedNonInvasive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NonInvasiveId = new SelectList(db.NonInvasiveSet, "NonInvasiveId", "ScientificName", savedNonInvasive.NonInvasiveId);
            return View(savedNonInvasive);
        }

        // GET: SavedNonInvasives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavedNonInvasive savedNonInvasive = db.SavedNonInvasiveSet.Find(id);
            if (savedNonInvasive == null)
            {
                return HttpNotFound();
            }
            return View(savedNonInvasive);
        }

        // POST: SavedNonInvasives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavedNonInvasive savedNonInvasive = db.SavedNonInvasiveSet.Find(id);
            db.SavedNonInvasiveSet.Remove(savedNonInvasive);
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
