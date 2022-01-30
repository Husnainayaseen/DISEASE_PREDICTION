using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult index(int? id)
        {
            if (id != null)
            {
                TempData["catid"] = id;
            }
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string name, string email, string password)
        {
            int v = db.TBL_ADMIN.Where(x => x.ADMIN_NAME == name && x.ADMIN_EMAIL == email && x.ADMIN_PASSWORD == password).Count();
            if (v > 0)
            {
                return RedirectToAction("indexadmin");
            }
            else
            {
                ViewBag.loginerror = "Invalid Data";
                return View();
            }


        }
        public ActionResult add_expense()
        {
            return View();
        }
        public ActionResult indexadmin()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        } public ActionResult customerlogin()
        {
            return View();
        }
        [HttpPost] public ActionResult customerlogin(TBL_PATIENT patient)
        {
            if (patient.PATIENT_NAME == null || patient.PATIENT_LOCATION == null || patient.PATIENT_PhoneNo == null)
            {
                TBL_PATIENT p = db.TBL_PATIENT.Where(x => x.PATIENT_Email == patient.PATIENT_Email && x.Patient_EmailPassword == patient.Patient_EmailPassword).FirstOrDefault();

                if (p != null)
                {
                    current_user.currentpatient = p;
                    return RedirectToAction("index");

                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email And Password')</script>";
                }
                    }
            if (ModelState.IsValid)
            {
                db.TBL_PATIENT.Add(patient);
                db.SaveChanges();
                ViewBag.msg = "<script> alert('Account Is Created Successfully')</script>";
            }
            return View();
        }
        public ActionResult portfolio()
        {
            return View();
        }
        public ActionResult pricing()
        {
            return View();
        }
        public ActionResult services(int? id)
        {
            if (id != null)
            {
                TempData["catid"] = id;
            }
            return View();
        }
        public ActionResult medicine
             ()
        {
            return View();
        }

    }
}