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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            NewSubjectProfile nsp = new NewSubjectProfile();
            return View(nsp);
        }

        // POST: /Subjects/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(NewSubjectProfile newSubjectModel)
        {
            try
            {
                using (SubjectsContext db = new SubjectsContext())
                {
                    SubjectProfile subjectModel = new SubjectProfile();
                    subjectModel.Credits = newSubjectModel.Credits;
                    subjectModel.Description = newSubjectModel.Description;
                    subjectModel.Guarantor = newSubjectModel.Guarantor;
                    subjectModel.Name = newSubjectModel.Name;
                    subjectModel.Prerequsites = newSubjectModel.Prerequsites;
                    subjectModel.FacultyId = newSubjectModel.FacultyID;


                    
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
        // GET: /Subjects/Edit
        [Authorize(Roles = "Admin, gurantor")]
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
        // POST: /Subjects/Edit
        [Authorize(Roles = "Admin, gurantor")]
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
        // GET: /Subjects/Delete
        [Authorize(Roles = "Admin")]
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

        public List<SelectListItem> GetSubjectForFaculties(int facultyId)
        {
            List<SelectListItem> subjectList = new List<SelectListItem>();

            using (SubjectsContext db = new SubjectsContext())
            {
                foreach (var theSubject in db.SubjectProfiles.ToList())
                {
                    if (theSubject.FacultyId == facultyId)
                    {
                        subjectList.Add(new SelectListItem() { Selected = false, Text = theSubject.Name, Value = theSubject.id.ToString() });
                    }
                }
            }

            return subjectList;
        }

        public List<SelectListItem> GetAllSubjects()
        {
            List<SelectListItem> subjectList = new List<SelectListItem>();

            using (SubjectsContext db = new SubjectsContext())
            {
                foreach (var theSubject in db.SubjectProfiles.ToList())
                {
                    subjectList.Add(new SelectListItem() { Selected = false, Text = theSubject.Name, Value = theSubject.id.ToString() });
                }
            }

            return subjectList;
        }

    }
}