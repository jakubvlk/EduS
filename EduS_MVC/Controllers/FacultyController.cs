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

        public List<SelectListItem> GetFacultiesList()
        {
            List<SelectListItem> facultiesList = new List<SelectListItem>();
            
            using (FacultiesContext db = new FacultiesContext())
            {
                foreach (var theFaculty in db.Faculties.ToList())
                {
                    facultiesList.Add(new SelectListItem() { Selected = false, Text = theFaculty.Name, Value = theFaculty.FacultyId.ToString() });
                }
            }

            return facultiesList;
        }
    }
}
