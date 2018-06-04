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
    public class BikeBrandsController : Controller
    {
        private StoreCatalogContext db = new StoreCatalogContext();

        // GET: BikeBrands
        public ActionResult Index()
        {
            return View(db.brands.ToList());
        }

        // GET: BikeBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeBrand bikeBrand = db.brands.Find(id);
            if (bikeBrand == null)
            {
                return HttpNotFound();
            }
            return View(bikeBrand);
        }

        // GET: BikeBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeBrandID,Name,Description")] BikeBrand bikeBrand)
        {
            if (ModelState.IsValid)
            {
                db.brands.Add(bikeBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bikeBrand);
        }

        // GET: BikeBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeBrand bikeBrand = db.brands.Find(id);
            if (bikeBrand == null)
            {
                return HttpNotFound();
            }
            return View(bikeBrand);
        }

        // POST: BikeBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeBrandID,Name,Description")] BikeBrand bikeBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bikeBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bikeBrand);
        }

        // GET: BikeBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeBrand bikeBrand = db.brands.Find(id);
            if (bikeBrand == null)
            {
                return HttpNotFound();
            }
            return View(bikeBrand);
        }

        // POST: BikeBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BikeBrand bikeBrand = db.brands.Find(id);
            db.brands.Remove(bikeBrand);
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
