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
        public int Id { get; set; }

        [Display(Name = "Pain Scale")] 
        public SelectList PainRating { get; set; }

        [Display(Name = "Location of pain")] 
        public SelectList PainLocation { get; set; }

        [Display(Name = "Amount of sleep last night")] 
        public SelectList AmountOfSleep { get; set; }

        [Display(Name = "Level of Activity Today")] 
        public SelectList ActivityLevel { get; set; }

    }
}