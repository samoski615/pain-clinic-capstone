using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models.ViewModels
{
    public class ListsViewModel
    {
        public int PainScore { get; set; }
        public SelectList PainScores { get; set; }

        public string PainLocation { get; set; }
        public SelectList PainLocations { get; set; }

        public int HoursOfSleep { get; set; }
        public SelectList HoursOfSleepNightly { get; set; }

        public string ActivityLevelToday { get; set; }
        public SelectList ActivityLevelsToday { get; set; }

    }

    

}