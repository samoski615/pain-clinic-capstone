﻿using System;
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

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime TodaysDate { get; set; }

        [Display(Name = "Pain Scale")] 
        public string PainRating { get; set; }

        [Display(Name = "Location of pain")] 
        public string PainLocation { get; set; }

        [Display(Name = "Amount of sleep last night")] 
        public string AmountOfSleep { get; set; }

        [Display(Name = "Level of Activity Today")] 
        public string ActivityLevel { get; set; }  
        
        [Display(Name = "Brief description of events: ")]
        //[DataType(DataType.Text)]
        public string DailyActivities { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

    }
}