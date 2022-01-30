using DISEASE_PREDICTION.Models;
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
        }public ActionResult minusfromcart(int id)
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