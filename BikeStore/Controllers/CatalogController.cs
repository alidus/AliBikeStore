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
    public class CatalogController : Controller
    {
        private StoreCatalogContext db = new StoreCatalogContext();

        // GET: Catalog
        public ActionResult Index()
        {
            var bikes = db.bikes.Include(b => b.BikeBrand);
            ViewBag.BikeSpecs = db.specs;
            return View(bikes.ToList());
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            ViewBag.BikeBrandID = new SelectList(db.brands, "BikeBrandID", "Name");
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeID,BikeBrandID,Model,Description,Price")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BikeBrandID = new SelectList(db.brands, "BikeBrandID", "Name", bike.BikeBrandID);
            return View(bike);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            ViewBag.BikeBrandID = new SelectList(db.brands, "BikeBrandID", "Name", bike.BikeBrandID);
            return View(bike);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeID,BikeBrandID,Model,Description,Price")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BikeBrandID = new SelectList(db.brands, "BikeBrandID", "Name", bike.BikeBrandID);
            return View(bike);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bike bike = db.bikes.Find(id);
            db.bikes.Remove(bike);
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
