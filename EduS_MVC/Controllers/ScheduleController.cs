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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SelectSubject()
        {
            return View();
        }
        //
        // POST: /Schedule/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
                    individualModel.StartDate = newIndividualModel.StartDate;
                    individualModel.EndDate = newIndividualModel.EndDate;
                    individualModel.FacultyId = newIndividualModel.FacultyId;
                    individualModel.Capacity = newIndividualModel.Capacity;
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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult EditSubject(int? id)
        {
            IndividualModel individualModel;
            try
            {
                using (ScheduleContext db = new ScheduleContext())
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSubject(int? id, IndividualModel newIndividualModel)//(int id, FormCollection collection)
        {
            try
            {
                using (ScheduleContext db = new ScheduleContext())
                {
                    IndividualModel individualModel = db.ScheduleDB.SingleOrDefault(h => h.Id == id);
                 //   individualModel.Name = newIndividualModel.Name;
                   // individualModel.Description = newIndividualModel.Description;
                    individualModel.MO9 = newIndividualModel.MO9;
                    individualModel.MO12 = newIndividualModel.MO12;
                    individualModel.MO16 = newIndividualModel.MO16;
                    individualModel.TU9 = newIndividualModel.TU9;
                    individualModel.TU12 = newIndividualModel.TU12;
                    individualModel.TU16 = newIndividualModel.TU16;
                    individualModel.WE9 = newIndividualModel.WE9;
                    individualModel.WE12 = newIndividualModel.WE12;
                    individualModel.WE16 = newIndividualModel.WE16;
                    individualModel.TH9 = newIndividualModel.TH9;
                    individualModel.TH12 = newIndividualModel.TH12;
                    individualModel.TH16 = newIndividualModel.TH16;
                    individualModel.FR9 = newIndividualModel.FR9;
                    individualModel.FR12 = newIndividualModel.FR12;
                    individualModel.FR16 = newIndividualModel.FR16;
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

        void GetSubjectsName()
        {

        }

  
     
   
    }
}
