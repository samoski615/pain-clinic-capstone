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
        //Patient DataViewModel -- use for creating and accessing data related to a patient
       
        public Patient Patient { get; set; }
        public List<Patient> Patients { get; set; }
        public DailyPainJournal DailyPainJournal { get; set; }
        public List<DailyPainJournal> GetDailyLogs { get; set; }
        public Provider Provider { get; set; }
        
       
    }
}