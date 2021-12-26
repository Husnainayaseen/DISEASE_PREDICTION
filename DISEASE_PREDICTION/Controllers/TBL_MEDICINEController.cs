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
    public class TBL_MEDICINEController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_MEDICINE
        public ActionResult Index()
        {
            var tBL_MEDICINE = db.TBL_MEDICINE.Include(t => t.TBL_DISEASECATEGORY).Include(t => t.TBL_MEDICINECOMPANY);
            return View(tBL_MEDICINE.ToList());
        }

        // GET: TBL_MEDICINE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
            if (tBL_MEDICINE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MEDICINE);
        }

        // GET: TBL_MEDICINE/Create
        public ActionResult Create()
        {
            ViewBag.DISEASECATEGORY_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION");
            ViewBag.MED_COMPANY_FID = new SelectList(db.TBL_MEDICINECOMPANY, "COMPANY_ID", "COMPANY_NAME");
            return View();
        }

        // POST: TBL_MEDICINE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TBL_MEDICINE tBL_MEDICINE,HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/Projectpics/"+ pic.FileName);
            pic.SaveAs(fullpath);
            tBL_MEDICINE.MED_IMAGE = "~/content/Projectpics/" + pic.FileName;
            if (ModelState.IsValid)
            {
                db.TBL_MEDICINE.Add(tBL_MEDICINE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DISEASECATEGORY_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_MEDICINE.DISEASECATEGORY_FID);
            ViewBag.MED_COMPANY_FID = new SelectList(db.TBL_MEDICINECOMPANY, "COMPANY_ID", "COMPANY_NAME", tBL_MEDICINE.MED_COMPANY_FID);
            return View(tBL_MEDICINE);
        }

        // GET: TBL_MEDICINE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
            if (tBL_MEDICINE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DISEASECATEGORY_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_MEDICINE.DISEASECATEGORY_FID);
            ViewBag.MED_COMPANY_FID = new SelectList(db.TBL_MEDICINECOMPANY, "COMPANY_ID", "COMPANY_NAME", tBL_MEDICINE.MED_COMPANY_FID);
            return View(tBL_MEDICINE);
        }

        // POST: TBL_MEDICINE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TBL_MEDICINE tBL_MEDICINE,HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/Projectpics/" + pic.FileName);
                pic.SaveAs(fullpath);
                tBL_MEDICINE.MED_IMAGE = "~/content/Projectpics/" + pic.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tBL_MEDICINE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DISEASECATEGORY_FID = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION", tBL_MEDICINE.DISEASECATEGORY_FID);
            ViewBag.MED_COMPANY_FID = new SelectList(db.TBL_MEDICINECOMPANY, "COMPANY_ID", "COMPANY_NMAE", tBL_MEDICINE.MED_COMPANY_FID);
            return View(tBL_MEDICINE);
        }

        // GET: TBL_MEDICINE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
            if (tBL_MEDICINE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MEDICINE);
        }

        // POST: TBL_MEDICINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
            db.TBL_MEDICINE.Remove(tBL_MEDICINE);
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
