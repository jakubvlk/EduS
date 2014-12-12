using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduS_MVC.Models
{
    public class AllSubjectModel
    {
        public List<SubjectProfile> AllSubjects{ get; set; }

         public AllSubjectModel()
        {
            AllSubjects = new List<SubjectProfile>();
        }
    }
}