using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class DailyLog
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int DailyLogId { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime TodaysDate { get; set; }

        [Display(Name = "Pain Scale")] 
        public SelectList PainRating { get; set; }

        [Display(Name = "Location of pain")] 
        public SelectList PainLocation { get; set; }

        [Display(Name = "Amount of sleep last night")] 
        public SelectList AmountOfSleep { get; set; }

        [Display(Name = "Level of Activity Today")] 
        public SelectList ActivityLevel { get; set; }  
        
        [Display(Name = "Brief description of events: ")]
        [DataType(DataType.Text)]
        public string DailyActivities { get; set; }
    }
}