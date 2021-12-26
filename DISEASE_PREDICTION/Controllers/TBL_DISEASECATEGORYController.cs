using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DISEASE_PREDICTION.Models;

namespace DISEASE_PREDICTION.Controllers
{
    public class TBL_DISEASECATEGORYController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_DISEASECATEGORY
        public ActionResult Index()
        {
            return View(db.TBL_DISEASECATEGORY.ToList());
        }

        // GET: TBL_DISEASECATEGORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASECATEGORY tBL_DISEASECATEGORY = db.TBL_DISEASECATEGORY.Find(id);
            if (tBL_DISEASECATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DISEASECATEGORY);
        }

        // GET: TBL_DISEASECATEGORY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_DISEASECATEGORY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DISEASE_ID,DISEASE_DESCRIPTION")] TBL_DISEASECATEGORY tBL_DISEASECATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.TBL_DISEASECATEGORY.Add(tBL_DISEASECATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_DISEASECATEGORY);
        }

        // GET: TBL_DISEASECATEGORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASECATEGORY tBL_DISEASECATEGORY = db.TBL_DISEASECATEGORY.Find(id);
            if (tBL_DISEASECATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DISEASECATEGORY);
        }

        // POST: TBL_DISEASECATEGORY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DISEASE_ID,DISEASE_DESCRIPTION")] TBL_DISEASECATEGORY tBL_DISEASECATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DISEASECATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_DISEASECATEGORY);
        }

        // GET: TBL_DISEASECATEGORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASECATEGORY tBL_DISEASECATEGORY = db.TBL_DISEASECATEGORY.Find(id);
            if (tBL_DISEASECATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DISEASECATEGORY);
        }

        // POST: TBL_DISEASECATEGORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DISEASECATEGORY tBL_DISEASECATEGORY = db.TBL_DISEASECATEGORY.Find(id);
            db.TBL_DISEASECATEGORY.Remove(tBL_DISEASECATEGORY);
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
