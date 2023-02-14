using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class AppointmentController : Controller
    {
        Model1 db = new Model1();
        // GET: Appointment
        public ActionResult doctor(int? id, string gender)
        {
            TBL_DOCTOR doc = new TBL_DOCTOR();

            if (id != null || gender != null)
            {
                ViewData["gender"] = gender;
                ViewData["spID"] = id;
            }

            return View();
        }
        public ActionResult doctor_detail(string ID, int? Date)
        {
            if (ID == null)
            {
                return RedirectToAction("doctor");
            }
            //parse is used to convert string to int
            int id = Int32.Parse(ID);
            ViewData["ID"] = id;
            TempData["date"] = Date;
            TempData.Peek("date");

            return View();
        }
        public ActionResult book_Appointment()
        {
            if (current_user.currentpatient == null)
            {
                return RedirectToAction("customerlogin", "home");
            }
            //TBL_APPOINTMENT ap = (TBL_APPOINTMENT)Session["Appointment"];
            //int v = db.TBL_APPOINTMENT.Where(x => x.SCH_FID == ap.SCH_FID && x.PATIENT_FID == current_user.currentpatient.PATIENT_ID && x.APP_DATE == ap.APP_DATE).Count();
            //if (v > 0)
            //{
            //    TempData["Alreadyappoint"] = "<script>alert('You have already an appointment of same date with same doctor')</script>";
            //    return RedirectToAction("doctor_detail", new { id = ap.TBL_SCHEDULE.DOC_FID });

            //}
               return View();
        }
        public ActionResult Add_Appointment(int id, DateTime Date)
        {
            if (current_user.currentpatient == null)
            {
                return RedirectToAction("customerlogin", "home");
            }
            TBL_SCHEDULE sch = db.TBL_SCHEDULE.Where(x => x.SCH_ID == id).FirstOrDefault();
            List<TBL_SCHEDULE> Schlist = new List<TBL_SCHEDULE>();

            if (Session["schlist"] != null)
            {
                //typecasting ki h (list ki)
                Schlist = (List<TBL_SCHEDULE>)Session["schlist"];

            }
            TBL_SCHEDULE existing = Schlist.Where(x => x.SCH_ID == id).FirstOrDefault();

            if (db.TBL_APPOINTMENT.Any(x => DbFunctions.TruncateTime(x.APP_DATE.Value) == Date.Date && x.SCH_FID == id))
            {
                TempData["Alreadyappoint"] = "<script>alert('You have already an appointment of same date with same doctor')</script>";
                return RedirectToAction("doctor_detail",new { id =id});
            }
            Schlist.Add(sch);

            Session["AppDate"] = Date;
            Session["schlist"] = Schlist;
            TBL_APPOINTMENT ap = new TBL_APPOINTMENT();
            //int v = db.TBL_APPOINTMENT.Where(x => x.SCH_FID == id && x.APP_DATE == Date && x.APP_STATUS == "Confirmed").Count();
            //if (v > Int32.Parse(ap.TBL_SCHEDULE.MAX_APP.ToString()))
            //{
            //    TempData["FilledAppointment"] = "<script> alert('Each doctor have limited No of Appointment on ech day so we are sorry you cannot book this appointment because schedule is already full')</script>";
            //}
            return RedirectToAction("book_Appointment");
        }

        public ActionResult Save_Appointment(TBL_APPOINTMENT ap, string method)
        {
            foreach (var item in (List<TBL_SCHEDULE>)Session["schlist"])
            {
                ap.SCH_FID = item.SCH_ID;
                ap.PATIENT_FID = current_user.currentpatient.PATIENT_ID;
                ap.APP_STATUS = "Confirmed";
                ap.APP_FEE_STATUS = method;
                ap.APP_DATE = DateTime.Parse(Session["AppDate"].ToString()).Date;
            }
            //ap.TBL_SCHEDULE  = db.TBL_SCHEDULE.Where(x => x.SCH_ID == ap.SCH_FID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.TBL_APPOINTMENT.Add(ap);
                db.SaveChanges();
                TempData["msg"] = "<script> alert('your Appointment has been booked')</script>";
            }
            string mailbody = "Dear user your appointment has been confirmed with our doctor at your selected date and day";
            EmailProvider.Email(current_user.currentpatient.PATIENT_Email, "Appointment Confirmation", mailbody);
            Session["Appointment"] = ap;
            List<TBL_SCHEDULE> list = new List<TBL_SCHEDULE>();
            list.Add(db.TBL_SCHEDULE.Where(x => x.SCH_ID == ap.SCH_FID).FirstOrDefault());
            Session["App_List"] = list;
            return RedirectToAction("book_Appointment");
        }

        public ActionResult MyAppointment()
        {
            return View();
        }
        public ActionResult Reschedule(int id, DateTime date)
        {
            TBL_APPOINTMENT app = db.TBL_APPOINTMENT.Find(id);
            app.APP_DATE =  date;
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Your Appointment has been Reschedule')</script>";
            return RedirectToAction("MyAppointment");
        }
        public ActionResult RemoveApp( int id)
        {
            
                TBL_APPOINTMENT app = db.TBL_APPOINTMENT.Find(id);
                db.TBL_APPOINTMENT.Remove(app);
                db.SaveChanges();
            TempData["remove"] = "<script> alert('your Appointment has been Removed')</script>";

            return RedirectToAction("MyAppointment");                   
       }
        public ActionResult DocLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DocLogin(string name, string email, string password)
        {
            TBL_DOCTOR doc=db.TBL_DOCTOR.Where(x=>x.DOC_NAME==name&&x.DOC_EMAIL==email&&x.DOC_PASSWORD==password).FirstOrDefault();
            if (doc != null)
            {
                current_user.currentdoctor = doc;
                return RedirectToAction("docprofile");
            }
            else {
                ViewBag.loginerror = "Invalid Data";
                return View();
            }
            
        }
        public ActionResult docprofile()
        {
            return View();
        }
    }

}