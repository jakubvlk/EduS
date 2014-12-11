using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduS_MVC.Models
{
    public class AllUsersModel
    {
        public List<UserProfile> AllUsers { get; set; }

        public AllUsersModel()
        {
            AllUsers = new List<UserProfile>();
        }
    }
}