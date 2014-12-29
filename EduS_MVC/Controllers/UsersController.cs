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

        public UserProfile GetUserByID(int userID)
        {
            AllUsersModel allUsersModel = new AllUsersModel();
            using (UsersContext db = new UsersContext())
            {
               return db.UserProfiles.FirstOrDefault(u => u.UserId == userID);
            }
            
            return null;
        }

        public void SetUserSchedule(int userID, int? scheduleId)
        {
            AllUsersModel allUsersModel = new AllUsersModel();
            using (UsersContext db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserId == userID);

                user.ScheduleId = scheduleId;

                db.SaveChanges();
            }
        }
    }
}