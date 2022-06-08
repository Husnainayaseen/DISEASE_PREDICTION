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
    public class TBL_PATIENTController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_PATIENT
        public ActionResult Index()
        {
            return View(db.TBL_PATIENT.ToList());
        }

        // GET: TBL_PATIENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PATIENT tBL_PATIENT = db.TBL_PATIENT.Find(id);
            if (tBL_PATIENT == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PATIENT);
        }

        // GET: TBL_PATIENT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_PATIENT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PATIENT_ID,PATIENT_AGE,PATIENT_GENDER,PATIENT_LOCATION,PATIENT_NAME,PATIENT_PhoneNo,PATIENT_Email,PATIENT_EmailPassword,PATIENT_DISEASE,PATIENT_APPOINTMENTDATE")] TBL_PATIENT tBL_PATIENT)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PATIENT.Add(tBL_PATIENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PATIENT);
        }

        // GET: TBL_PATIENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PATIENT tBL_PATIENT = db.TBL_PATIENT.Find(id);
            if (tBL_PATIENT == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PATIENT);
        }

        // POST: TBL_PATIENT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PATIENT_ID,PATIENT_AGE,PATIENT_GENDER,PATIENT_LOCATION,PATIENT_NAME,PATIENT_FATHERNAME,PATIENT_DISEASE,PATIENT_APPOINTMENTDATE")] TBL_PATIENT tBL_PATIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PATIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PATIENT);
        }

        // GET: TBL_PATIENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PATIENT tBL_PATIENT = db.TBL_PATIENT.Find(id);
            if (tBL_PATIENT == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PATIENT);
        }

        // POST: TBL_PATIENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PATIENT tBL_PATIENT = db.TBL_PATIENT.Find(id);
            db.TBL_PATIENT.Remove(tBL_PATIENT);
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
