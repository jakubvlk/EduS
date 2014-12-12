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
            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (SubjectsContext db = new SubjectsContext())
                {
                    foreach (var theSubjectProfile in db.SubjectProfiles.ToList())
                    {
                        allSubjectModel.AllSubjects.Add(theSubjectProfile);
                    }
                }
            }

            return View(allSubjectModel);
        }
    }
}