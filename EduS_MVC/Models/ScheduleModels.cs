using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace EduS_MVC.Models
{
    public class ScheduleModels
    {
    }
    public class ScheduleContext : DbContext
    {
        public ScheduleContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<IndividualModel> ScheduleDB { get; set; }
    }

    public class ScheduleModel
    {
        [Display(Name = "Schedule")]
        public List<IndividualModel> Schedule { get; set; }

        public ScheduleModel()
        {
            Schedule = new List<IndividualModel>();
        }
    }

    [Table("Schedule")]
    public class IndividualModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Schedule Name")]
        public string Name { get; set; }

        [Display(Name = "Schedule Description")]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Display(Name = "FacultyId")]
        public string FacultyId { get; set; }

        [Display(Name = "Capacity")]
        public string Capacity { get; set; }

        [Display(Name = "MO9")]
        public string MO9 { get; set; }

        [Display(Name = "MO12")]
        public string MO12 { get; set; }

        [Display(Name = "MO16")]
        public string MO16 { get; set; }

        [Display(Name = "TU9")]
        public string TU9 { get; set; }

        [Display(Name = "TU12")]
        public string TU12 { get; set; }

        [Display(Name = "TU16")]
        public string TU16 { get; set; }

        [Display(Name = "WE9")]
        public string WE9 { get; set; }

        [Display(Name = "WE12")]
        public string WE12 { get; set; }

        [Display(Name = "WE16")]
        public string WE16 { get; set; }

        [Display(Name = "TH9")]
        public string TH9 { get; set; }

        [Display(Name = "TH12")]
        public string TH12 { get; set; }

        [Display(Name = "TH16")]
        public string TH16 { get; set; }

        [Display(Name = "FR9")]
        public string FR9 { get; set; }

        [Display(Name = "FR12")]
        public string FR12 { get; set; }

        [Display(Name = "FR16")]
        public string FR16 { get; set; }
    }
}