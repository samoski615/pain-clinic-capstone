using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientDailyLogViewModel
    {
        public Patient Patient { get; set; }
        public DailyLog DailyLog { get; set; }


        //public PatientDataViewModel(Patient patient)
        //{
        //    Patient = patient;
        //    DailyLog = new DailyLog();
        //}
    }
}