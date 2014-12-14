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
    }
}