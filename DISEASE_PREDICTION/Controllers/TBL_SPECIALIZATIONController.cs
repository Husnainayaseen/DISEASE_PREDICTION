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
    public class TBL_SPECIALIZATIONController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_SPECIALIZATION
        public ActionResult Index()
        {
            return View(db.TBL_SPECIALIZATION.ToList());
        }

        // GET: TBL_SPECIALIZATION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SPECIALIZATION tBL_SPECIALIZATION = db.TBL_SPECIALIZATION.Find(id);
            if (tBL_SPECIALIZATION == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SPECIALIZATION);
        }

        // GET: TBL_SPECIALIZATION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_SPECIALIZATION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SP_ID,SPECIALIZATION")] TBL_SPECIALIZATION tBL_SPECIALIZATION)
        {
            if (ModelState.IsValid)
            {
                db.TBL_SPECIALIZATION.Add(tBL_SPECIALIZATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_SPECIALIZATION);
        }

        // GET: TBL_SPECIALIZATION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SPECIALIZATION tBL_SPECIALIZATION = db.TBL_SPECIALIZATION.Find(id);
            if (tBL_SPECIALIZATION == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SPECIALIZATION);
        }

        // POST: TBL_SPECIALIZATION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SP_ID,SPECIALIZATION")] TBL_SPECIALIZATION tBL_SPECIALIZATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_SPECIALIZATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_SPECIALIZATION);
        }

        // GET: TBL_SPECIALIZATION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SPECIALIZATION tBL_SPECIALIZATION = db.TBL_SPECIALIZATION.Find(id);
            if (tBL_SPECIALIZATION == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SPECIALIZATION);
        }

        // POST: TBL_SPECIALIZATION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_SPECIALIZATION tBL_SPECIALIZATION = db.TBL_SPECIALIZATION.Find(id);
            db.TBL_SPECIALIZATION.Remove(tBL_SPECIALIZATION);
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
