using DISEASE_PREDICTION.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{ 
    public class AdminsideController : Controller
    {
        Model1 db = new Model1();
        // GET: Adminside
       
        public ActionResult NewOrders()
        {
            var orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Booked").OrderByDescending(x => x.ORDER_DATE).ToList();
            return View(orders);
        } 
        public ActionResult Proceedorders()
            {
              var orders = db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Proceed").OrderByDescending(x => x.ORDER_DATE).ToList();
                return View(orders);
    }
    public ActionResult deliveredorders()
        {
          var orders=  db.TBL_ORDER.Where(x => x.ORDER_STATUS == "Delivered").OrderByDescending(x=>x.ORDER_DATE).ToList();
            return View(orders);
        }
        public ActionResult invoice(int id)
        {
        var order=db.TBL_ORDER.Where(x => x.ORDER_ID == id).FirstOrDefault();
            return View(order);
        }
       
         public ActionResult AddToProceed(int id)
        {
        var order=db.TBL_ORDER.Where(x => x.ORDER_ID == id).FirstOrDefault();
            order.ORDER_STATUS = "Proceed";
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Order Updated') </script>";          
            return RedirectToAction("proceedorders");
        }
        public ActionResult AddTOdelivered(int id)
        {
        var order=db.TBL_ORDER.Where(x => x.ORDER_ID == id).FirstOrDefault();
            order.ORDER_STATUS = "Delivered";
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Order Delivered') </script>";
            return RedirectToAction("deliveredorders");
        }
    }
}