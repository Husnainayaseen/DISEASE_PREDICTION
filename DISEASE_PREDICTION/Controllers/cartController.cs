using DISEASE_PREDICTION.Models;
using DISEASE_PREDICTION.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class cartController : Controller
    {
        Model1 db = new Model1();
        int Quantity;
        // GET: cart
        public ActionResult addtocart(int id)
        {
            List<TBL_MEDICINE> cartlist = new List<TBL_MEDICINE>();
            if (Session["cart"] != null)
            {
                cartlist = (List<TBL_MEDICINE>)Session["cart"];
            }
            TBL_MEDICINE existingmedicine = cartlist.Where(x => x.MED_ID == id).FirstOrDefault();
            if (existingmedicine != null)
            {
                existingmedicine.Quantity++;
            }
            
            
                TBL_MEDICINE tBL_MEDICINE1 = db.TBL_MEDICINE.Where(x => x.MED_ID == id).FirstOrDefault();
                tBL_MEDICINE1.Quantity = 1;
                cartlist.Add(tBL_MEDICINE1);
                Session["cart"] = cartlist;
                // TBL_MEDICINE tBL_MEDICINE = db.TBL_MEDICINE.Find(id);
                return RedirectToAction("displaycart");
            
        } public ActionResult displaycart()
        {
            return View();
        }  public ActionResult orderbooked(TBL_ORDER order)
        {
            order.ORDER_DATE = System.DateTime.Now;
            order.ORDER_STATUS = "booked";
            order.ORDER_TYPE = "Sale";
            order.PAYMENTMODE = "COD";
            order.PATIENT_FID = current_user.currentpatient.PATIENT_ID;         
                db.TBL_ORDER.Add(order);
                db.SaveChanges();
             

            foreach (var item in (List<TBL_MEDICINE>)Session["cart"])
            {
                TBL_ORDERDETAIL od = new TBL_ORDERDETAIL();
                od.MEDICINE_FID = item.MED_ID;
                od.MED_QUANTITY= item.Quantity;
                od.MED_SALE_PRICE =item.MED_SALE_PRICE;
                od.MED_PURCHASE_PRICE = item.MED_PURCHASE_PRICE;
                od.ORDER_FID = order.ORDER_ID;
                db.TBL_ORDERDETAIL.Add(od);
                db.SaveChanges();
            }
            string mailBody = "Your order has been confirmend.Your order will be delivered in 3 days.";
            EmailProvider.Email(order.ORDER_EMAIL, "order Conformation",mailBody);
            TempData["order"] = Session["cart"];
            Session["cart"] = null;
            return RedirectToAction("orderbooked");
        } public ActionResult removefromcart(int id)
        {
            List<TBL_MEDICINE> list = new List<TBL_MEDICINE>();
            list =(List<TBL_MEDICINE>) Session["cart"];
            list.RemoveAt(id);
            Session["cart"] = list;
           return RedirectToAction("displaycart");
        }public ActionResult plustocart(int id)
        {
            List<TBL_MEDICINE> list = new List<TBL_MEDICINE>();
            list =(List<TBL_MEDICINE>) Session["cart"];
            list[id].Quantity++;
            Session["cart"] = list;
           return RedirectToAction("displaycart");

        }
        public ActionResult Completeorder()
        {
            return View();
        }


        public ActionResult minusfromcart(int id)
        {
            List<TBL_MEDICINE> list = new List<TBL_MEDICINE>();
            list =(List<TBL_MEDICINE>) Session["cart"];
            list[id].Quantity--;
            if (list[id].Quantity < 1)
            {
                list.RemoveAt(id);
            }
            Session["cart"] = list;
           return RedirectToAction("displaycart");
        }
    }
}