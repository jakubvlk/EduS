using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduS_MVC.Models;

namespace EduS_MVC.Controllers
{
    public class FacultyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public SelectList GetFacultiesList()
        {
            List<string> facultiesList = new List<string>();
            
            using (FacultiesContext db = new FacultiesContext())
            {
                foreach (var theFaculty in db.Faculties.ToList())
                {
                    facultiesList.Add(theFaculty.Name);
                }
            }

            return new SelectList(facultiesList);
        }
    }
}
