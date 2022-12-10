using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;

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
        }public ActionResult feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult feedback(string FEEDBACK_NAME, string FEEDBACK_EMAIL, string comment)
        {
            TBL_FEEDBACK feedback = new TBL_FEEDBACK(); 
            if (current_user.currentpatient != null)
            {
                
                feedback.FEEDBACK_DETAIL = comment;
                
                feedback.PATIENT_FID = current_user.currentpatient.PATIENT_ID;
                ViewBag.msg1 = "<script>alert('Thanks For Giving Your Feedback')</script>";
            }
            else
            {
                feedback.FEEDBACK_EMAIL = FEEDBACK_EMAIL;
                feedback.PATIENT_FID =null;
                feedback.FEEDBACK_NAME = FEEDBACK_NAME;
                ViewBag.msg = "<script>alert('Thanks for giving feedback.It would be very precious for us')</script>";
            }
            db.TBL_FEEDBACK.Add(feedback);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult login(string name, string email, string password)
        {
            TBL_ADMIN v = db.TBL_ADMIN.Where(x => x.ADMIN_NAME == name && x.ADMIN_EMAIL == email && x.ADMIN_PASSWORD == password).FirstOrDefault();
            if (v !=null)
            {
                current_user.currentadmin = v;
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
            var user = (TBL_PATIENT)Session["userforgetpassword"];
            user.PATIENT_EmailPassword = password;
            db.Entry(user).State =EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "Password Updated successfully";
            return RedirectToAction("customerlogin");

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
            string receiverEmail = "mazeenbilla0@gmail.com";
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
            if (current_user.currentadmin == null)
            {
                return RedirectToAction("login");
            }
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
        public ActionResult customerlogin(string PATIENT_NAME,string PATIENT_PhoneNo, string PATIENT_Email, string PATIENT_EmailPassword,string PATIENT_LOCATION)
        {
            TBL_PATIENT p=new TBL_PATIENT();
            p.PATIENT_NAME = PATIENT_NAME;
            p.PATIENT_PhoneNo = PATIENT_PhoneNo;
            p.PATIENT_Email = PATIENT_Email;
            p.PATIENT_EmailPassword = PATIENT_EmailPassword;
            p.PATIENT_LOCATION = PATIENT_LOCATION;
            if (p.PATIENT_NAME == null || p.PATIENT_LOCATION == null || p.PATIENT_PhoneNo == null)
            {
                TBL_PATIENT patient = db.TBL_PATIENT.Where(x => x.PATIENT_Email == p.PATIENT_Email && x.PATIENT_EmailPassword == p.PATIENT_EmailPassword).FirstOrDefault();

                if (patient != null)
                {
                    current_user.currentpatient = patient;
                    if (Session["cart"] != null)
                    {
                        return RedirectToAction("displaycart", "cart");
                    }
                    else if(Session["cart"]==null)
                    {
                        return RedirectToAction("Index");
                    }
                    else{
                        return RedirectToAction("checkout");
                    }
                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email And Password')</script>";
                }
            }

            if (ModelState.IsValid)
            {
                db.TBL_PATIENT.Add(p);
                db.SaveChanges();
                ViewBag.msg = "<script> alert('Account Is Created Successfully')</script>";
            }
            if (Session["Schlist"] != null)
            {
                return RedirectToAction("book_Appointment","Appointment");
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
        public ActionResult medicine ()
        {
            return View();
        } public ActionResult Logout ()
        {
            current_user.currentadmin = null;
                //FormsAuthentication.SignOut();
                return RedirectToAction("login");           
        } public ActionResult PatientLogout ()
        {
            current_user.currentpatient = null;
                FormsAuthentication.SignOut();
                return RedirectToAction("customerlogin");
        }
    }
}