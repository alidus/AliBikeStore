using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    public class SpecsController : Controller
    {
        private StoreCatalogContext db = new StoreCatalogContext();

        // GET: Specs
        public ActionResult Index()
        {
            var specs = db.specs.Include(s => s.Bike).Include(s => s.SpecType);
            return View(specs.ToList());
        }

        // GET: Specs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.specs.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            return View(spec);
        }

        // GET: Specs/Create
        public ActionResult Create()
        {
            ViewBag.BikeID = new SelectList(db.bikes, "BikeID", "Model");
            ViewBag.SpecTypeID = new SelectList(db.specTypes, "SpecTypeID", "TypeName");
            return View();
        }

        // POST: Specs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecID,BikeID,SpecTypeID,Value")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                db.specs.Add(spec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BikeID = new SelectList(db.bikes, "BikeID", "Model", spec.BikeID);
            ViewBag.SpecTypeID = new SelectList(db.specTypes, "SpecTypeID", "TypeName", spec.SpecTypeID);
            return View(spec);
        }

        // GET: Specs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.specs.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            ViewBag.BikeID = new SelectList(db.bikes, "BikeID", "Model", spec.BikeID);
            ViewBag.SpecTypeID = new SelectList(db.specTypes, "SpecTypeID", "TypeName", spec.SpecTypeID);
            return View(spec);
        }

        // POST: Specs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecID,BikeID,SpecTypeID,Value")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BikeID = new SelectList(db.bikes, "BikeID", "Model", spec.BikeID);
            ViewBag.SpecTypeID = new SelectList(db.specTypes, "SpecTypeID", "TypeName", spec.SpecTypeID);
            return View(spec);
        }

        // GET: Specs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.specs.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            return View(spec);
        }

        // POST: Specs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spec spec = db.specs.Find(id);
            db.specs.Remove(spec);
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
