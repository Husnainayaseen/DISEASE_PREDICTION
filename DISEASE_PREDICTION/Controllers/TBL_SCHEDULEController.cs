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
    public class TBL_SCHEDULEController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_SCHEDULE
        public ActionResult Index()
        {
            var tBL_SCHEDULE = db.TBL_SCHEDULE.Include(t => t.TBL_DOCTOR).Include(t => t.TBL_SCH_DAY);
            return View(tBL_SCHEDULE.ToList());
        }

        // GET: TBL_SCHEDULE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SCHEDULE tBL_SCHEDULE = db.TBL_SCHEDULE.Find(id);
            if (tBL_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SCHEDULE);
        }

        // GET: TBL_SCHEDULE/Create
        public ActionResult Create()
        {
            ViewBag.DOC_FID = new SelectList(db.TBL_DOCTOR, "DOC_ID", "DOC_NAME");
            ViewBag.SCH_DAY_FID = new SelectList(db.TBL_SCH_DAY, "SCH_DAY_ID", "SCH_DAY");
            return View();
        }

        // POST: TBL_SCHEDULE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCH_ID,SCH_DAY_FID,FEE,START_TIME,END_TIME,MAX_APP,DOC_FID")] TBL_SCHEDULE tBL_SCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.TBL_SCHEDULE.Add(tBL_SCHEDULE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOC_FID = new SelectList(db.TBL_DOCTOR, "DOC_ID", "DOC_NAME", tBL_SCHEDULE.DOC_FID);
            ViewBag.SCH_DAY_FID = new SelectList(db.TBL_SCH_DAY, "SCH_DAY_ID", "SCH_DAY", tBL_SCHEDULE.SCH_DAY_FID);
            return View(tBL_SCHEDULE);
        }

        // GET: TBL_SCHEDULE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SCHEDULE tBL_SCHEDULE = db.TBL_SCHEDULE.Find(id);
            if (tBL_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOC_FID = new SelectList(db.TBL_DOCTOR, "DOC_ID", "DOC_NAME", tBL_SCHEDULE.DOC_FID);
            ViewBag.SCH_DAY_FID = new SelectList(db.TBL_SCH_DAY, "SCH_DAY_ID", "SCH_DAY", tBL_SCHEDULE.SCH_DAY_FID);
            return View(tBL_SCHEDULE);
        }

        // POST: TBL_SCHEDULE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCH_ID,SCH_DAY_FID,FEE,START_TIME,END_TIME,MAX_APP,DOC_FID")] TBL_SCHEDULE tBL_SCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_SCHEDULE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOC_FID = new SelectList(db.TBL_DOCTOR, "DOC_ID", "DOC_NAME", tBL_SCHEDULE.DOC_FID);
            ViewBag.SCH_DAY_FID = new SelectList(db.TBL_SCH_DAY, "SCH_DAY_ID", "SCH_DAY", tBL_SCHEDULE.SCH_DAY_FID);
            return View(tBL_SCHEDULE);
        }

        // GET: TBL_SCHEDULE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SCHEDULE tBL_SCHEDULE = db.TBL_SCHEDULE.Find(id);
            if (tBL_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SCHEDULE);
        }

        // POST: TBL_SCHEDULE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_SCHEDULE tBL_SCHEDULE = db.TBL_SCHEDULE.Find(id);
            db.TBL_SCHEDULE.Remove(tBL_SCHEDULE);
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
