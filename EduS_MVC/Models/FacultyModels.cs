using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EduS_MVC.Models
{
    public class FacultiesContext : DbContext
    {
        public FacultiesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<FacultyModel> Faculties { get; set; }
    }

    [Table("Faculty")]
    public class FacultyModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }

        [Required]
        [Display(Name = "Faculty Name")]
        public string Name { get; set; }
    }
}