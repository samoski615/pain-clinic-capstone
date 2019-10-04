using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models.ViewModels
{

    public class PatientDataViewModel
    {
        //Patient DataViewModel -- use for creating and accessing a new DailyPainJournal 

       
        public Patient Patient { get; set; }
        public List<Patient> Patients { get; set; }
        public DailyPainJournal DailyPainJournal { get; set; }
        public List<DailyPainJournal> GetDailyLogs { get; set; }
        public Provider Provider { get; set; }
        
        //public int PainScore { get; set; }
        //[NotMapped]
        //public SelectList PainScores { get; set; }

        //public string PainLocation { get; set; }
        //[NotMapped]
        //public SelectList PainLocations { get; set; }

        //public int HoursOfSleep { get; set; }
        //[NotMapped]
        //public SelectList HoursOfSleepNightly { get; set; }

        //public string ActivityLevelToday { get; set; }
        //[NotMapped]
        //public SelectList ActivityLevelsToday { get; set; }

    }
}