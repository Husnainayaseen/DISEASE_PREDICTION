using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class PurchaseController : Controller
    {
        Model1 db = new Model1();
        // GET: Purchase
        public ActionResult AllMedicine()
        {
            return View(db.TBL_MEDICINE.ToList());
        } 
        public ActionResult AddToCart(int id,int qty)
        {
            List<TBL_MEDICINE> cartlist = new List<TBL_MEDICINE>();
            if (Session["pcart"] != null)
            {
                cartlist = (List<TBL_MEDICINE>)Session["pcart"];
            }
            TBL_MEDICINE existingmedicine = cartlist.Where(x => x.MED_ID == id).FirstOrDefault();
            if (existingmedicine != null)
            {
                existingmedicine.Quantity++;
            }


            TBL_MEDICINE tBL_MEDICINE1 = db.TBL_MEDICINE.Where(x => x.MED_ID == id).FirstOrDefault();
            tBL_MEDICINE1.Quantity += qty;
            cartlist.Add(tBL_MEDICINE1);
            Session["pcart"] = cartlist;
            // TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
            return RedirectToAction("displaycart");

        }
        public ActionResult displaycart()
        {
            var cartlist=(List<TBL_MEDICINE>)Session[ "pcart"];
            return View(cartlist);
        }
        public ActionResult OrderComplete()
        {
            return View();
        } public ActionResult Newpurchase()
        {
          var orders=  db.TBL_ORDER.Where(x => (x.ORDER_TYPE == "Purchase")&&(x.ORDER_STATUS=="Complete")).OrderByDescending(x => x.ORDER_DATE).ToList();
            
            return View(orders);
        }
        public ActionResult SavePurchase()
        {
            TBL_ORDER order = new TBL_ORDER();
            order.ADMIN_FID = current_user.currentadmin.ADMIN_ID;
            order.ORDER_DATE = DateTime.Now;
            order.ORDER_STATUS = "Complete";
            order.PAYMENTMODE = "Cash in Hand";
            order.ORDER_TYPE = "Purchase";
            db.TBL_ORDER.Add(order);
            db.SaveChanges();
            var cartlist = (List<TBL_MEDICINE>)Session["pcart"];

            foreach (var item in cartlist)
            {
                TBL_ORDERDETAIL od = new TBL_ORDERDETAIL();
                od.MEDICINE_FID = item.MED_ID;
                od.MED_QUANTITY = item.Quantity;
                od.MED_SALE_PRICE = item.MED_SALE_PRICE;
                od.MED_PURCHASE_PRICE = item.MED_PURCHASE_PRICE;
                od.ORDER_FID = order.ORDER_ID;
                db.TBL_ORDERDETAIL.Add(od);
                db.SaveChanges();
            }
            TempData["porder"] = Session["pcart"];
            Session["pcart"] = null;
            return RedirectToAction("OrderComplete");
        }
       
    }
}