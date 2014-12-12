using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EduS_MVC.Models
{
    public class HarmonogramContext : DbContext
    {
        public HarmonogramContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<EventModel> HarmonogramDB { get; set; }
    }

    public class HarmonogramModel
    {
        [Display(Name = "Harmonogram" )]
        public List<EventModel> Harmonogram { get; set; }

        public HarmonogramModel()
        {
            Harmonogram = new List<EventModel>();
        }
    }

    public class EventModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [Display(Name = "Event Description")]
        public string Description { get; set; }
    }


}