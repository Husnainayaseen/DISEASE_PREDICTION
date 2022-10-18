using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult doctor(int? id)
        {
            if (id != null)
            {
                ViewData["spID"] = id;
            }
            return View();
        }public ActionResult doctor_detail()
        {
            return View();
        }
    }
}