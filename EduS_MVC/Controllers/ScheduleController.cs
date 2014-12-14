using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduS_MVC.Models;

namespace EduS_MVC.Controllers
{
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        public ActionResult Schedule()
        {
            ScheduleModel schModel = new ScheduleModel();
            //harmModel.Harmonogram.Add(new EventModel() { Name = "omg", Description = "wtf" });

            using (ScheduleContext db = new ScheduleContext())
            {
                foreach (var newSchedule in db.ScheduleDB.ToList())
                {
                    schModel.Schedule.Add(newSchedule);
                }
            }

            return View(schModel);
        }

        public ActionResult AddSubject()
        {
            ScheduleModel schModel = new ScheduleModel();
            //harmModel.Harmonogram.Add(new EventModel() { Name = "omg", Description = "wtf" });

            using (ScheduleContext db = new ScheduleContext())
            {
                foreach (var newSchedule in db.ScheduleDB.ToList())
                {
                    schModel.Schedule.Add(newSchedule);
                }
            }

            return View(schModel);
        }

        //
        // GET: /Schedule/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Schedule/Create

        [HttpPost]
        public ActionResult Create(IndividualModel individualModel)
        {
            try
            {
                using (ScheduleContext db = new ScheduleContext())
                {
                    db.ScheduleDB.Add(individualModel);
                    db.Entry(individualModel).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }

                return RedirectToAction("Schedule");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Edit/5

        public ActionResult Edit(int? id)
        {
            IndividualModel individualModel;
            try
            {
                using (ScheduleContext db = new ScheduleContext ())
                {
                    individualModel = db.ScheduleDB.SingleOrDefault(h => h.Id == id);

                    return View(individualModel);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Schedule/Edit/5

        [HttpPost]
        public ActionResult Edit(int? id, IndividualModel newIndividualModel)//(int id, FormCollection collection)
        {
            try
            {
                using (ScheduleContext db = new ScheduleContext())
                {
                    IndividualModel individualModel = db.ScheduleDB.SingleOrDefault(h => h.Id == id);
                    individualModel.Name = newIndividualModel.Name;
                    individualModel.Description = newIndividualModel.Description;
                    db.Entry(individualModel).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Schedule");
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /Schedule/Delete/5

        public ActionResult Delete(int? id)
        {
            IndividualModel individualModel;
            try
            {
                using (ScheduleContext db = new ScheduleContext())
                {
                    individualModel = db.ScheduleDB.SingleOrDefault(h => h.Id == id);
                    db.ScheduleDB.Remove(individualModel);

                    db.SaveChanges();

                    return RedirectToAction("Schedule");
                }
            }
            catch
            {
                return RedirectToAction("Schedule");
            }
        }
    }
}
