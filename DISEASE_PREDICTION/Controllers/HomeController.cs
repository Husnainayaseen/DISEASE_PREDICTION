using DISEASE_PREDICTION.Models;
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
        public ActionResult index()
        {
            return View();
        }   public ActionResult login()
        {
            return View();
        }  
        [HttpPost]
        public ActionResult login(string name,string email,string password)
        {
          int v=  db.TBL_ADMIN.Where(x => x.ADMIN_NAME == name && x.ADMIN_EMAIL == email && x.ADMIN_PASSWORD == password).Count();
            if (v > 0)
            {
                return RedirectToAction("indexadmin");
            }
            else
            {
                ViewBag.loginerror = "Invalid Data";
                return View();
            }

            
        }  public ActionResult add_expense ()
        {
            return View();
        }public ActionResult indexadmin()
        {
            return View();
        }
        public ActionResult about ()
        {
            return View();
        }  public ActionResult contact ()
        {
            return View();
        }  public ActionResult portfolio ()
        {
            return View();
        }  public ActionResult pricing ()
        {
            return View();
        }  public ActionResult services ()
        {
            return View();
        }
     
    }
}