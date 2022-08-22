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