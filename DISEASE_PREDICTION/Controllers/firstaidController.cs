using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class firstaidController : Controller
    {
        // GET: firstaid
        public ActionResult Incident()
        {
            return View();
        }
    }
}