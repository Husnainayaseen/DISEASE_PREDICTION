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
    public class TBL_DOCTORController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_DOCTOR
        public ActionResult Index()
        {
            var tBL_DOCTOR = db.TBL_DOCTOR.Include(t => t.TBL_SPECIALIZATION);
            return View(tBL_DOCTOR.ToList());
        }

        // GET: TBL_DOCTOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DOCTOR tBL_DOCTOR = db.TBL_DOCTOR.Find(id);
            if (tBL_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DOCTOR);
        }

        // GET: TBL_DOCTOR/Create
        public ActionResult Create()
        {
            ViewBag.SP_FID = new SelectList(db.TBL_SPECIALIZATION, "SP_ID", "SPECIALIZATION");
            return View();
        }

        // POST: TBL_DOCTOR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TBL_DOCTOR tBL_DOCTOR, HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/Projectpics/" + pic.FileName);
            pic.SaveAs(fullpath);
            tBL_DOCTOR.DOC_PIC = "~/content/Projectpics/" + pic.FileName;
            if (ModelState.IsValid)
            {
                db.TBL_DOCTOR.Add(tBL_DOCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SP_FID = new SelectList(db.TBL_SPECIALIZATION, "SP_ID", "SPECIALIZATION", tBL_DOCTOR.SP_FID);
            return View(tBL_DOCTOR);
        }

        // GET: TBL_DOCTOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DOCTOR tBL_DOCTOR = db.TBL_DOCTOR.Find(id);
            if (tBL_DOCTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.SP_FID = new SelectList(db.TBL_SPECIALIZATION, "SP_ID", "SPECIALIZATION", tBL_DOCTOR.SP_FID);
            return View(tBL_DOCTOR);
        }

        // POST: TBL_DOCTOR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TBL_DOCTOR tBL_DOCTOR,HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/Projectpics/" + pic.FileName);
            pic.SaveAs(fullpath);
            tBL_DOCTOR.DOC_PIC = "~/content/Projectpics/" + pic.FileName;
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DOCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SP_FID = new SelectList(db.TBL_SPECIALIZATION, "SP_ID", "SPECIALIZATION", tBL_DOCTOR.SP_FID);
            return View(tBL_DOCTOR);
        }

        // GET: TBL_DOCTOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DOCTOR tBL_DOCTOR = db.TBL_DOCTOR.Find(id);
            if (tBL_DOCTOR == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DOCTOR);
        }

        // POST: TBL_DOCTOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DOCTOR tBL_DOCTOR = db.TBL_DOCTOR.Find(id);
            db.TBL_DOCTOR.Remove(tBL_DOCTOR);
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
