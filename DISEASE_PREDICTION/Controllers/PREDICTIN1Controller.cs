using DISEASE_PREDICTION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISEASE_PREDICTION.Controllers
{
    public class PREDICTIN1Controller : Controller
    {
        // GET: PREDICTIN1
        Model1 db = new Model1();
        [HttpGet]
      
        public ActionResult Index()
        {
            var data = new SympAndDisViewModel()
            {
                symp = db.TBL_SYMPTOMS.ToList(),
                dis = db.TBL_DISEASECATEGORY.ToList()
            };
            return View(data);
            //if (prediction != null)
            //{
            //    ViewBag.data = prediction;
            //}
            //return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            List<TBL_DISEASE_SYMPTOM> sd;
            //string symList="select * from symptom where Id=";
            //string strIDs = "15|20|30";
            ///List<string> IDs = collection["symp"].Split(',').Select(s => (s).ToString()).ToList();
            SympAndDisViewModel filterData = new SympAndDisViewModel()
            {
                symp = db.TBL_SYMPTOMS.ToList(),
                dis = db.TBL_DISEASECATEGORY.ToList()
            };
            if (collection["symp"] != null)
            {

                List<int> IDs = collection["symp"].Split(',').Select(s => int.Parse(s)).ToList();

                List<TBL_DISEASE_SYMPTOM> verify_Disease = new List<TBL_DISEASE_SYMPTOM>();
                List<int> disease_Ids;
                List<int> final = new List<int>();

                Dictionary<int, double> record = new Dictionary<int, double>();
                int totalNumberOf, semiTotalNumberOf;
                sd = new List<TBL_DISEASE_SYMPTOM>();
                sd = db.TBL_DISEASE_SYMPTOM.ToList();
                //List<symp_disease> distinct_Record;
                // ViewBag.ids = "yes";
                verify_Disease = db.TBL_DISEASE_SYMPTOM.Where(x => IDs.Contains((int)x.SYMPTOM_FID)).ToList();
                disease_Ids = verify_Disease.Select(x => x.DISEASE_FID).Distinct().ToList();

                if (disease_Ids.Count > 0)
                {
                    foreach (int k in disease_Ids)
                    {
                        ViewBag.ids = ViewBag.ids + "" + k + "=>";
                        totalNumberOf = (int)sd.Where(x => x.DISEASE_FID == k).ToList().Count;

                        semiTotalNumberOf = (int)verify_Disease.Where(x => x.DISEASE_FID == k).ToList().Count;
                        //int ratio = Convert.ToInt32((semiTotalNumberOf / totalNumberOf) * 100);
                        double ratio = (semiTotalNumberOf / (double)totalNumberOf) * 100;
                        //ViewBag.ids = ViewBag.ids + "" + semiTotalNumberOf + "" + totalNumberOf + " =>" + ratio + "  new==";
                        if (ratio > 1)
                        {
                            final.Add(k);
                            record.Add(k, ratio);
                            //ViewBag.ids = ViewBag.ids + "" + disease_Ids[i];


                        }

                    }
                    //for (int i=0; i<=disease_Ids.Count; i++)
                    //{


                    //}
                    if (final.Count != 0)
                    {

                        ViewBag.data = from pair in record
                                       orderby pair.Value descending
                                       select pair;
                        //ViewBag.ids = ViewBag.ids + " after list=" + String.Join("; ", final) + "=>";
                        filterData = new SympAndDisViewModel()
                        {

                            symp = db.TBL_SYMPTOMS.Where(m => IDs.Contains((int)m.SYMPTOM_ID)).OrderBy(m => m.DISEASE_SYMPTOMS).ToList(),
                            dis = db.TBL_DISEASECATEGORY.Where(m => final.Contains((int)m.DISEASE_ID)).OrderBy(m => m.DISEASE_DESCRIPTION).ToList()
                        };

                    }

                }
                
            }


            return View(filterData);
        }


    }
}