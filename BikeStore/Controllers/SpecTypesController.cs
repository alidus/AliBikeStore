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
    public class SpecTypesController : Controller
    {
        private StoreCatalogContext db = new StoreCatalogContext();

        // GET: SpecTypes
        public ActionResult Index()
        {
            return View(db.specTypes.ToList());
        }

        // GET: SpecTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecType specType = db.specTypes.Find(id);
            if (specType == null)
            {
                return HttpNotFound();
            }
            return View(specType);
        }

        // GET: SpecTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecTypeID,TypeName")] SpecType specType)
        {
            if (ModelState.IsValid)
            {
                db.specTypes.Add(specType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specType);
        }

        // GET: SpecTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecType specType = db.specTypes.Find(id);
            if (specType == null)
            {
                return HttpNotFound();
            }
            return View(specType);
        }

        // POST: SpecTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecTypeID,TypeName")] SpecType specType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specType);
        }

        // GET: SpecTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecType specType = db.specTypes.Find(id);
            if (specType == null)
            {
                return HttpNotFound();
            }
            return View(specType);
        }

        // POST: SpecTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecType specType = db.specTypes.Find(id);
            db.specTypes.Remove(specType);
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
