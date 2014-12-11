using EduS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EduS_MVC.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/AllUsers
        [Authorize(Roles = "admin")]
        public ActionResult AllUsers()
        {
            AllUsersModel allUsersModel = new AllUsersModel();
            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    foreach (var theUserProfile in db.UserProfiles.ToList())
                    {
                        allUsersModel.AllUsers.Add(theUserProfile);
                    }
                }
            }

            return View(allUsersModel);
        }
    }
}