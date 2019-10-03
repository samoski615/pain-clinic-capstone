using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class DailyPainJournal
    {
        //Patient's DailyPainJournal info

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int DailyPainJournalId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        [Required]
        [Display(Name = "Pain Scale")] 
        public string PainRating { get; set; }

        [Required]
        [Display(Name = "Location of pain")] 
        public string PainLocation { get; set; }

        [Required]
        [Display(Name = "Hours of sleep last night")] 
        public string AmountOfSleep { get; set; }

        [Required]
        [Display(Name = "Level of Activity Today")] 
        public string ActivityLevel { get; set; }

        [Required]
        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)]
        public DateTime SearchDate { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }


        //[Display(Name = "Brief description of events: ")]
        ////[DataType(DataType.Text)]
        //public string DailyActivities { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime Date { get; set; }
    }
}