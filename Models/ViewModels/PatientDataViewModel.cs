using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientDataViewModel
    {
        public Patient Patient { get; set; }
        public DailyLog DailyLog { get; set; }

    }
}