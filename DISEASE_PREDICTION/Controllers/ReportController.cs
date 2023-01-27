using DISEASE_PREDICTION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class ReportController : Controller
    {
        Model1 db = new Model1();
        // GET: Report
     public ActionResult SalesReport(DateTime? Datefrom,DateTime? Dateto,int? category,int?medicine)
        {
            if (Datefrom == null)
            {
                Datefrom = DateTime.Today;                
            }
            if (Dateto == null)
            {
                Dateto = DateTime.Now;             
            }
            ViewBag.Datefrom = Datefrom.Value.ToString("s");
            ViewBag.Dateto = Dateto.Value.ToString("s");
            
            ViewBag.DISEASECATEGORY = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION");
            ViewBag.MEDICINE = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME");
           var orders = new List<TBL_ORDER>();
            if (category != null)
            {
                orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
               orders= orders.Where(x => x.TBL_ORDERDETAIL.Any(z => z.TBL_MEDICINE.DISEASECATEGORY_FID == category)).ToList();
            }
            if (medicine != null)
            {
                orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
                orders = orders.Where(x => x.TBL_ORDERDETAIL.Any(z => z.MEDICINE_FID == medicine)).ToList();
            }
            else
            {
                 orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
            }
            return View(orders);
        } public ActionResult AppointmentReport(DateTime? Datefrom,DateTime? Dateto,int? SPECIALIZATION,int?DOCTOR)
        {
            if (Datefrom == null)
            {
                Datefrom = DateTime.Today;                
            }
            if (Dateto == null)
            {
                Dateto = DateTime.Now;             
            }
            ViewBag.Datefrom = Datefrom.Value.ToString("s");
            ViewBag.Dateto = Dateto.Value.ToString("s");
            
            ViewBag.SPECIALIZATION = new SelectList(db.TBL_SPECIALIZATION, "SP_ID", "SPECIALIZATION");
            ViewBag.DOCTOR = new SelectList(db.TBL_DOCTOR, "DOC_ID", "DOC_NAME");
           var app = new List<TBL_APPOINTMENT>();
            if (SPECIALIZATION != null)
            {
                app = db.TBL_APPOINTMENT.Where(x => x.APP_STATUS == "Confirmed" && x.APP_DATE >= Datefrom && x.APP_DATE <= Dateto).OrderByDescending(x => x.APP_DATE).ToList();
                app = app.Where(x => x.TBL_SCHEDULE.TBL_DOCTOR.SP_FID == SPECIALIZATION).ToList();/*Any(z =>z.TBL_DOCTOR.SP_FID == SPECIALIZATION)).ToList();*/
            }
            if (DOCTOR != null)
            {
                app = db.TBL_APPOINTMENT.Where(x => x.APP_STATUS == "Confirmed" && x.APP_DATE >= Datefrom && x.APP_DATE <= Dateto).OrderByDescending(x => x.APP_DATE).ToList();
                app = app.Where(x => x.TBL_SCHEDULE.DOC_FID == DOCTOR).ToList();/*Any(z => z.DOC_FID == DOCTOR)).ToList();*/
            }
            else
            {
                app = db.TBL_APPOINTMENT.Where(x => x.APP_STATUS == "Confirmed" && x.APP_DATE >= Datefrom && x.APP_DATE <= Dateto).OrderByDescending(x => x.APP_DATE).ToList();
            }
            return View(app);
        } 
    
        public ActionResult PurchaseReport(DateTime? Datefrom,DateTime? Dateto,int? category,int?medicine)
        {
            if (Datefrom == null)
            {
                Datefrom = DateTime.Today;                
            }
            if (Dateto == null)
            {
                Dateto = DateTime.Now;             
            }
            ViewBag.Datefrom = Datefrom.Value.ToString("s");
            ViewBag.Dateto = Dateto.Value.ToString("s");
            
            ViewBag.DISEASECATEGORY = new SelectList(db.TBL_DISEASECATEGORY, "DISEASE_ID", "DISEASE_DESCRIPTION");
            ViewBag.MEDICINE = new SelectList(db.TBL_MEDICINE, "MED_ID", "MED_NAME");
           var orders = new List<TBL_ORDER>();
            if (category != null)
            {
                orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Complete"&& x.ADMIN_FID!=null && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
               orders= orders.Where(x => x.TBL_ORDERDETAIL.Any(z => z.TBL_MEDICINE.DISEASECATEGORY_FID == category)).ToList();
            }
            if (medicine != null)
            {
                orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Complete" && x.ADMIN_FID != null && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
                orders = orders.Where(x => x.TBL_ORDERDETAIL.Any(z => z.MEDICINE_FID == medicine)).ToList();
            }
            else
            {
                 orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Complete" && x.ADMIN_FID != null && x.ORDER_DATE >= Datefrom && x.ORDER_DATE <= Dateto).OrderByDescending(x => x.ORDER_DATE).ToList();
            }
            return View(orders);
        }
        public ActionResult StockReport()
        {
           var p =db.TBL_MEDICINE.ToList();
            return View(p);
        }

        public ActionResult profit()
        {
           var p = db.TBL_ORDER.ToList();
            return View(p);
        } 

    }
}