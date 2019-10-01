using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientDataViewModel
    {
        //Patient DataViewModel -- use for creating a new DailyPainJournal 

        public int Id { get; set; }
        public Patient Patient { get; set; }
        public List<Patient> Patients { get; set; }
        public DailyPainJournal DailyPainJournal { get; set; }
        public List<DailyPainJournal> GetDailyLogs { get; set; }

      
    }
}