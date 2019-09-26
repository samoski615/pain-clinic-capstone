using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientRegistrationViewModel
    {
        public Patient Patient { get; set; }
        public Addresses Addresses { get; set; }
        //public ProviderPatientDirectory Directory { get; set; }
        public Clinic Clinic { get; set; }
    }
}