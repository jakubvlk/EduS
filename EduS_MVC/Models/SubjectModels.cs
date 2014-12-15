﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace EduS_MVC.Models
{
    public class SubjectsContext : DbContext
    {
        public SubjectsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<SubjectProfile> SubjectProfiles { get; set; }
    }

     [Table("Subject")]
    public class SubjectProfile
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Display(Name = "Faculty")]
        //public int FacultyId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Guarantor")]
        public string Guarantor { get; set; }

        [Display(Name = "Prerequsites")]
        public string Prerequsites { get; set; }

        [Display(Name = "Credits")]
        public string Credits{ get; set; }



        /*
         public List<Faculty> faculties;
         public SubjectProfile()
         {
             faculties = new List<Faculty>();
         }
          */

        public SelectList GetAllGurantors()
        {
            try
            {
                var roleItems = Roles.GetUsersInRole("gurantor");

                return (new SelectList(roleItems));
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}