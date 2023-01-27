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
    public class TBL_DISEASE_SYMPTOMController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_DISEASE_SYMPTOM
        public ActionResult Index()
        {
            var tBL_DISEASE_SYMPTOM = db.TBL_DISEASE_SYMPTOM.Include(t => t.TBL_DISEASECATEGORY).Include(t => t.TBL_SYMPTOMS);
            return View(tBL_DISEASE_SYMPTOM.ToList());
        }

        // GET: TBL_DISEASE_SYMPTOM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM = db.TBL_DISEASE_SYMPTOM.Find(id);
            if (tBL_DISEASE_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DISEASE_SYMPTOM);
        }

        // GET: TBL_DISEASE_SYMPTOM/Create
        public ActionResult Create()
        {
            ViewBag.DISEASE_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION");
            ViewBag.SYMPTOM_FID = new SelectList(db.TBL_SYMPTOMS, "SYMPTOM_ID", "DISEASE_SYMPTOMS");
            return View();
        }

        // POST: TBL_DISEASE_SYMPTOM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DIS_SYMP_ID,SYMPTOM_FID,DISEASE_FID")] TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.TBL_DISEASE_SYMPTOM.Add(tBL_DISEASE_SYMPTOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DISEASE_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_DISEASE_SYMPTOM.DISEASE_FID);
            ViewBag.SYMPTOM_FID = new SelectList(db.TBL_SYMPTOMS, "SYMPTOM_ID", "DISEASE_SYMPTOMS", tBL_DISEASE_SYMPTOM.SYMPTOM_FID);
            return View(tBL_DISEASE_SYMPTOM);
        }

        // GET: TBL_DISEASE_SYMPTOM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM = db.TBL_DISEASE_SYMPTOM.Find(id);
            if (tBL_DISEASE_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            ViewBag.DISEASE_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_DISEASE_SYMPTOM.DISEASE_FID);
            ViewBag.SYMPTOM_FID = new SelectList(db.TBL_SYMPTOMS, "SYMPTOM_ID", "DISEASE_SYMPTOMS", tBL_DISEASE_SYMPTOM.SYMPTOM_FID);
            return View(tBL_DISEASE_SYMPTOM);
        }

        // POST: TBL_DISEASE_SYMPTOM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DIS_SYMP_ID,SYMPTOM_FID,DISEASE_FID")] TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DISEASE_SYMPTOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DISEASE_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_DISEASE_SYMPTOM.DISEASE_FID);
            ViewBag.SYMPTOM_FID = new SelectList(db.TBL_SYMPTOMS, "SYMPTOM_ID", "DISEASE_SYMPTOMS", tBL_DISEASE_SYMPTOM.SYMPTOM_FID);
            return View(tBL_DISEASE_SYMPTOM);
        }

        // GET: TBL_DISEASE_SYMPTOM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM = db.TBL_DISEASE_SYMPTOM.Find(id);
            if (tBL_DISEASE_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DISEASE_SYMPTOM);
        }

        // POST: TBL_DISEASE_SYMPTOM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DISEASE_SYMPTOM tBL_DISEASE_SYMPTOM = db.TBL_DISEASE_SYMPTOM.Find(id);
            db.TBL_DISEASE_SYMPTOM.Remove(tBL_DISEASE_SYMPTOM);
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
