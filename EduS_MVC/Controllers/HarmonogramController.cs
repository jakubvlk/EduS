using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduS_MVC.Models;

namespace EduS_MVC.Controllers
{
    public class HarmonogramController : Controller
    {
        //
        // GET: /Harmonogram/Harmonogram

        public ActionResult Harmonogram()
        {
            HarmonogramModel harmModel = new HarmonogramModel();

            using (HarmonogramContext db = new HarmonogramContext())
            {
                foreach (var theHarmonogramEvent in db.HarmonogramDB.ToList())
                {
                    harmModel.Harmonogram.Add(theHarmonogramEvent);
                }
            }

            return View(harmModel);
        }

       
        //
        // GET: /Harmonogram/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Harmonogram/Create

        [HttpPost]
        public ActionResult Create(EventModel eventModel)
        {
            try
            {
                using (HarmonogramContext db = new HarmonogramContext())
                {
                    db.HarmonogramDB.Add(eventModel);

                    db.Entry(eventModel).State = System.Data.EntityState.Added;

                    db.SaveChanges();
                }



                return RedirectToAction("Harmonogram");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Harmonogram/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Harmonogram/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Harmonogram/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Harmonogram/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
