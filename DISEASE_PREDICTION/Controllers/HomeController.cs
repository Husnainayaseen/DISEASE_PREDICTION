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

        } public ActionResult Newpassword()
        {
            return View();

        } [HttpPost]
                
     public ActionResult Newpassword(string password)
        {
            int user = (TBL_PATIENT)Session["userforgetpassword"];
            user.
            return View();

        } public ActionResult codeverify()
        {
            return View();

        }[HttpPost]
        public ActionResult codeverify(int code)
        {
            int sendcode = (int)Session["code"];
            if (sendcode == code)
            {
                return RedirectToAction("Newpassword");
            }
            TempData["error"] = "invalid code";
            return View();

        } public ActionResult ForgetPassword(string email)
        {
        var patient= db.TBL_PATIENT.Where(x => x.PATIENT_Email == email).FirstOrDefault();
            if (patient == null)
            {
                TempData["error"] = "Invalid Email";
                return RedirectToAction("customerlogin");
            }
            string receiverEmail = "husnainyaseen820@gmail.com";
            Random random = new Random();
            int code = random.Next(1001, 9990);
            string Emailsubject = "subject";
            string Emailbody = "your code is" +code;         
            Session["code"] = code;
            Session["userforgetpassword"] = patient;
            EmailProvider.Email(receiverEmail,Emailsubject,Emailbody);
            return RedirectToAction("codeverify");
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
            if (current_user.currentpatient == null)
            {
                return RedirectToAction("customerlogin", "home");
            }
            return View();
        }
        public ActionResult customerlogin()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult customerlogin(TBL_PATIENT patient)
        {
            if (patient.PATIENT_NAME == null || patient.PATIENT_LOCATION == null || patient.PATIENT_PhoneNo == null)
            {
                TBL_PATIENT p = db.TBL_PATIENT.Where(x => x.PATIENT_Email == patient.PATIENT_Email && x.Patient_EmailPassword == patient.Patient_EmailPassword).FirstOrDefault();

                if (p != null)
                {
                    current_user.currentpatient = p;
                    if (Session["cart"]!=null)
                    {
                        return RedirectToAction("displaycart","cart");
                    }
                    return RedirectToAction("checkout");

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