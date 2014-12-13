using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduS_MVC.Models
{
    public class AllSubjectModel
    {
        [Display(Name = "AllSubjects")]
        public List<SubjectProfile> AllSubjects{ get; set; }

         public AllSubjectModel()
        {
            AllSubjects = new List<SubjectProfile>();
        }
    }
}