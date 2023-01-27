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
    public class TBL_SYMPTOMSController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_SYMPTOMS
        public ActionResult Index()
        {
            var tBL_SYMPTOMS = db.TBL_SYMPTOMS/*.Include(t => t.TBL_MEDICINE)*/;
            return View(tBL_SYMPTOMS.ToList());
        }

        // GET: TBL_SYMPTOMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SYMPTOMS tBL_SYMPTOMS = db.TBL_SYMPTOMS.Find(id);
            if (tBL_SYMPTOMS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SYMPTOMS);
        }

        // GET: TBL_SYMPTOMS/Create
        public ActionResult Create()
        {
            ViewBag.MED_FID = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME");
            return View();
        }

        // POST: TBL_SYMPTOMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SYMPTOM_ID,DISEASE_SYMPTOMS/*,MED_FID*/")] TBL_SYMPTOMS tBL_SYMPTOMS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_SYMPTOMS.Add(tBL_SYMPTOMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.MED_FID = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME", tBL_SYMPTOMS.MED_FID);
            return View(tBL_SYMPTOMS);
        }

        // GET: TBL_SYMPTOMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SYMPTOMS tBL_SYMPTOMS = db.TBL_SYMPTOMS.Find(id);
            if (tBL_SYMPTOMS == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MED_FID = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME", tBL_SYMPTOMS.MED_FID);
            return View(tBL_SYMPTOMS);
        }

        // POST: TBL_SYMPTOMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SYMPTOM_ID,DISEASE_SYMPTOMS,MED_FID")] TBL_SYMPTOMS tBL_SYMPTOMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_SYMPTOMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.MED_FID = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME", tBL_SYMPTOMS.MED_FID);
            return View(tBL_SYMPTOMS);
        }

        // GET: TBL_SYMPTOMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SYMPTOMS tBL_SYMPTOMS = db.TBL_SYMPTOMS.Find(id);
            if (tBL_SYMPTOMS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SYMPTOMS);
        }

        // POST: TBL_SYMPTOMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_SYMPTOMS tBL_SYMPTOMS = db.TBL_SYMPTOMS.Find(id);
            db.TBL_SYMPTOMS.Remove(tBL_SYMPTOMS);
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
