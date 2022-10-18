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
    public class TBL_APPOINTMENTController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_APPOINTMENT
        public ActionResult Index()
        {
            var tBL_APPOINTMENT = db.TBL_APPOINTMENT.Include(t => t.TBL_SCHEDULE);
            return View(tBL_APPOINTMENT.ToList());
        }

        // GET: TBL_APPOINTMENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_APPOINTMENT tBL_APPOINTMENT = db.TBL_APPOINTMENT.Find(id);
            if (tBL_APPOINTMENT == null)
            {
                return HttpNotFound();
            }
            return View(tBL_APPOINTMENT);
        }

        // GET: TBL_APPOINTMENT/Create
        public ActionResult Create()
        {
            ViewBag.SCH_FID = new SelectList(db.TBL_SCHEDULE, "SCH_ID", "SCH_DAY");
            return View();
        }

        // POST: TBL_APPOINTMENT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APP_ID,APP_DATE,APP_STATUS,APP_FEE_STATUS,PATIENT_FID,SCH_FID")] TBL_APPOINTMENT tBL_APPOINTMENT)
        {
            if (ModelState.IsValid)
            {
                db.TBL_APPOINTMENT.Add(tBL_APPOINTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SCH_FID = new SelectList(db.TBL_SCHEDULE, "SCH_ID", "SCH_DAY", tBL_APPOINTMENT.SCH_FID);
            return View(tBL_APPOINTMENT);
        }

        // GET: TBL_APPOINTMENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_APPOINTMENT tBL_APPOINTMENT = db.TBL_APPOINTMENT.Find(id);
            if (tBL_APPOINTMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.SCH_FID = new SelectList(db.TBL_SCHEDULE, "SCH_ID", "SCH_DAY", tBL_APPOINTMENT.SCH_FID);
            return View(tBL_APPOINTMENT);
        }

        // POST: TBL_APPOINTMENT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APP_ID,APP_DATE,APP_STATUS,APP_FEE_STATUS,PATIENT_FID,SCH_FID")] TBL_APPOINTMENT tBL_APPOINTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_APPOINTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SCH_FID = new SelectList(db.TBL_SCHEDULE, "SCH_ID", "SCH_DAY", tBL_APPOINTMENT.SCH_FID);
            return View(tBL_APPOINTMENT);
        }

        // GET: TBL_APPOINTMENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_APPOINTMENT tBL_APPOINTMENT = db.TBL_APPOINTMENT.Find(id);
            if (tBL_APPOINTMENT == null)
            {
                return HttpNotFound();
            }
            return View(tBL_APPOINTMENT);
        }

        // POST: TBL_APPOINTMENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_APPOINTMENT tBL_APPOINTMENT = db.TBL_APPOINTMENT.Find(id);
            db.TBL_APPOINTMENT.Remove(tBL_APPOINTMENT);
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
