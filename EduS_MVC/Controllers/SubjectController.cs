using EduS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EduS_MVC.Controllers
{
    public class SubjectController : Controller
    {

        SubjectsContext db = new SubjectsContext();

        public ActionResult AllSubjects()
        {
            //AllSubjectModel
            AllSubjectModel allSubjectModel = new AllSubjectModel();
          //  if (ModelState.IsValid)
        //    {
                // Insert a new user into the database
                //allSubjectModel.AllSubjects.Add(new SubjectProfile() {id = 100, Name = "x", Description = "c", Guarantor = "a", Credits ="ff", Prerequsites = "x" });
            
                using (SubjectsContext db = new SubjectsContext())
                {
                    foreach (var theSubjectProfile in db.SubjectProfiles.ToList())
                    {
                        allSubjectModel.AllSubjects.Add(theSubjectProfile);
                    }
                }
          //  }

            return View(allSubjectModel);
        }

     
        // GET: /Subjects/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Subjects/Create
  
        [HttpPost]
        public ActionResult Create(SubjectProfile subjectModel)
        {
            try
            {
                using (SubjectsContext db = new SubjectsContext())
                {
                    db.SubjectProfiles.Add(subjectModel);

                    db.Entry(subjectModel).State = System.Data.EntityState.Added;

                    db.SaveChanges();
                }



                return RedirectToAction("AllSubjects");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subjects/Edit/5

        public ActionResult Edit(int? id)
        {
            SubjectProfile allSubjectModel;
            try
            {
                using (SubjectsContext db = new SubjectsContext())
                {
                    allSubjectModel = db.SubjectProfiles.SingleOrDefault(h => h.id == id);

                    return View(allSubjectModel);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Subjects/Edit/5

        [HttpPost]
        public ActionResult Edit(int? id, SubjectProfile newSubjectModel)
        {
            try
            {
                using (SubjectsContext db = new SubjectsContext())
                {
                    SubjectProfile subjectModel = db.SubjectProfiles.SingleOrDefault(h => h.id == id);

                    subjectModel.Name = newSubjectModel.Name;
                    subjectModel.Description = newSubjectModel.Description;
                    subjectModel.Guarantor = newSubjectModel.Guarantor;
                    subjectModel.Prerequsites= newSubjectModel.Prerequsites;
                    subjectModel.Credits = newSubjectModel.Credits;

                    db.Entry(subjectModel).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }


                return RedirectToAction("AllSubjects");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subjects/Delete/5

        public ActionResult Delete(int? id)
        {
            SubjectProfile subjectModel;
            try
            {
                using (SubjectsContext db = new SubjectsContext())
                {
                    subjectModel = db.SubjectProfiles.SingleOrDefault(h => h.id == id);
                    db.SubjectProfiles.Remove(subjectModel);

                    db.SaveChanges();

                    return RedirectToAction("AllSubjects");
                }
            }
            catch
            {
                return RedirectToAction("AllSubjects");
            }
        }

    }
}