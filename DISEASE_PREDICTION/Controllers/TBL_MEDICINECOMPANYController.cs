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
    public class TBL_MEDICINECOMPANYController : Controller
    {
        private Model1 db = new Model1();

        // GET: TBL_MEDICINECOMPANY
        public ActionResult Index()
        {
            return View(db.TBL_MEDICINECOMPANY.ToList());
        }

        // GET: TBL_MEDICINECOMPANY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY = db.TBL_MEDICINECOMPANY.Find(id);
            if (tBL_MEDICINECOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MEDICINECOMPANY);
        }

        // GET: TBL_MEDICINECOMPANY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_MEDICINECOMPANY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPANY_ID,COMPANY_NAME,COMPANY_LOGO,COMPANY_LOCATION,COMPANY_LICENSE")] TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.TBL_MEDICINECOMPANY.Add(tBL_MEDICINECOMPANY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_MEDICINECOMPANY);
        }

        // GET: TBL_MEDICINECOMPANY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY = db.TBL_MEDICINECOMPANY.Find(id);
            if (tBL_MEDICINECOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MEDICINECOMPANY);
        }

        // POST: TBL_MEDICINECOMPANY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPANY_ID,COMPANY_NMAE,COMPANY_LOGO,COMPANY_LOCATION,COMPANY_LICENSE")] TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_MEDICINECOMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_MEDICINECOMPANY);
        }

        // GET: TBL_MEDICINECOMPANY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY = db.TBL_MEDICINECOMPANY.Find(id);
            if (tBL_MEDICINECOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MEDICINECOMPANY);
        }

        // POST: TBL_MEDICINECOMPANY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_MEDICINECOMPANY tBL_MEDICINECOMPANY = db.TBL_MEDICINECOMPANY.Find(id);
            db.TBL_MEDICINECOMPANY.Remove(tBL_MEDICINECOMPANY);
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
