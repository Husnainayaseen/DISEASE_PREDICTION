using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class AppointmentController : Controller
    {
        Model1 db = new Model1();
        // GET: Appointment
        public ActionResult doctor(int? id,int? gender)
        {
            TBL_DOCTOR doc = new TBL_DOCTOR();
            if (id != null || gender != null)
            {
                if (gender == 1)
                {

                    var v = db.TBL_DOCTOR.Where(x => x.DOC_GENDER == "Male").ToList();
                    ViewData["gender1"] = v;


                }
                else if (gender == 2)
                {
                    var v = db.TBL_DOCTOR.Where(x => x.DOC_GENDER == "Female").ToList();
                    ViewData["gender2"] = v;
                }
                ViewData["gender"] = gender;
                ViewData["spID"] = id;
            }

            return View();
        }public ActionResult doctor_detail(string ID,int? Date)
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
            
            return View();
        }public ActionResult Add_Appointment(int id,DateTime Date)
        {
            if (current_user.currentpatient == null)
            {
                return RedirectToAction("customerlogin", "home");
            }
            TBL_SCHEDULE sch = db.TBL_SCHEDULE.Where(x => x.SCH_ID == id).FirstOrDefault();
            List<TBL_SCHEDULE> Schlist = new List<TBL_SCHEDULE>();
            List<DateTime> Datelist = new List<DateTime>();
            if (Session["schlist"]!=null)
            {
                //typecasting ki h (list ki)
                Schlist = (List<TBL_SCHEDULE>)Session["schlist"];
            }
            TBL_SCHEDULE existing=Schlist.Where(x=>x.SCH_ID==id).FirstOrDefault();
            DateTime matchingdate = Datelist.Where(x => x.Date == Date).FirstOrDefault();
            if (existing!=null&&matchingdate!=null)/* DateTime.Parse((string)Session["AppDate"]*/
            {
                TempData["Alreadyappoint"] = "<script>alert('You have already an appointment of same date with same doctor')</script>";
                return RedirectToAction("doctor_detail");
            }
            Schlist.Add(sch);
            Datelist.Add(Date);
            Session["AppDate"] = Datelist ;         
            Session["schlist"] = Schlist;
           //int v= db.TBL_APPOINTMENT.Where(x => x.SCH_FID == id && x.APP_DATE == Date && x.APP_STATUS == "Confirmed").Count();
           // if(v>Int32.Parse(db.TBL_SCHEDULE.MAX_APP.to))
            return RedirectToAction("book_Appointment");
        }
    }
}