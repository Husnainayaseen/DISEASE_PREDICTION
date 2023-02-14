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
    public class TBL_FEEDBACKController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_FEEDBACK
        public ActionResult Index()
        {
            var tBL_FEEDBACK = db.TBL_FEEDBACK.Include(t => t.TBL_PATIENT);
            return View(tBL_FEEDBACK.ToList());
        }

        // GET: TBL_FEEDBACK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_FEEDBACK tBL_FEEDBACK = db.TBL_FEEDBACK.Find(id);
            if (tBL_FEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(tBL_FEEDBACK);
        }

        // GET: TBL_FEEDBACK/Create
        public ActionResult Create()
        {
            ViewBag.PATIENT_FID = new SelectList(db.TBL_PATIENT, "PATIENT_ID", "PATIENT_GENDER");
            return View();
        }

        // POST: TBL_FEEDBACK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FEEDBACK_ID,PATIENT_FID,FEEDBACK_DETAIL,FEEDBACK_EMAIL,FEEDBACK_NAME")] TBL_FEEDBACK tBL_FEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.TBL_FEEDBACK.Add(tBL_FEEDBACK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PATIENT_FID = new SelectList(db.TBL_PATIENT, "PATIENT_ID", "PATIENT_GENDER", tBL_FEEDBACK.PATIENT_FID);
            return View(tBL_FEEDBACK);
        }

        // GET: TBL_FEEDBACK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_FEEDBACK tBL_FEEDBACK = db.TBL_FEEDBACK.Find(id);
            if (tBL_FEEDBACK == null)
            {
                return HttpNotFound();
            }
            ViewBag.PATIENT_FID = new SelectList(db.TBL_PATIENT, "PATIENT_ID", "PATIENT_GENDER", tBL_FEEDBACK.PATIENT_FID);
            return View(tBL_FEEDBACK);
        }

        // POST: TBL_FEEDBACK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FEEDBACK_ID,PATIENT_FID,FEEDBACK_DETAIL,FEEDBACK_EMAIL,FEEDBACK_NAME")] TBL_FEEDBACK tBL_FEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_FEEDBACK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PATIENT_FID = new SelectList(db.TBL_PATIENT, "PATIENT_ID", "PATIENT_GENDER", tBL_FEEDBACK.PATIENT_FID);
            return View(tBL_FEEDBACK);
        }

        // GET: TBL_FEEDBACK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_FEEDBACK tBL_FEEDBACK = db.TBL_FEEDBACK.Find(id);
            if (tBL_FEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(tBL_FEEDBACK);
        }

        // POST: TBL_FEEDBACK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_FEEDBACK tBL_FEEDBACK = db.TBL_FEEDBACK.Find(id);
            db.TBL_FEEDBACK.Remove(tBL_FEEDBACK);
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
