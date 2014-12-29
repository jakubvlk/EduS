using EduS_MVC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public int FacultyId { get; set; }

        [Display(Name = "Capacity")]
        public string Capacity { get; set; }

        [Display(Name = "MO9")]
        public int MO9 { get; set; }

        [Display(Name = "MO12")]
        public int MO12 { get; set; }

        [Display(Name = "MO16")]
        public int MO16 { get; set; }

        [Display(Name = "TU9")]
        public int TU9 { get; set; }

        [Display(Name = "TU12")]
        public int TU12 { get; set; }

        [Display(Name = "TU16")]
        public int TU16 { get; set; }

        [Display(Name = "WE9")]
        public int WE9 { get; set; }

        [Display(Name = "WE12")]
        public int WE12 { get; set; }

        [Display(Name = "WE16")]
        public int WE16 { get; set; }

        [Display(Name = "TH9")]
        public int TH9 { get; set; }

        [Display(Name = "TH12")]
        public int TH12 { get; set; }

        [Display(Name = "TH16")]
        public int TH16 { get; set; }

        [Display(Name = "FR9")]
        public int FR9 { get; set; }

        [Display(Name = "FR12")]
        public int FR12 { get; set; }

        [Display(Name = "FR16")]
        public int FR16 { get; set; }

        public List<SelectListItem> GetAllSubjectsForFaculty()
        {
            SubjectController subControl = new SubjectController();

            return subControl.GetSubjectForFaculties(FacultyId);
        }

        public string GetSubjectName(int subjectIndex)
        {
            SubjectController subControl = new SubjectController();

            List<SelectListItem> subjects = GetAllSubjectsForFaculty();

            SelectListItem sli = subjects.FirstOrDefault(s => s.Value.Equals(subjectIndex.ToString()));
            return sli.Text;
        }

        public bool IsUserInFaculty(int userID)
        {
            UserProfile user = new UsersController().GetUserByID(userID);

            if (user != null)
            {
                if (user.FacultyId == FacultyId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}