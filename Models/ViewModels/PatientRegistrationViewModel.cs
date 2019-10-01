using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientRegistrationViewModel
    {
        //ViewModel for maintaining patient records

        public Patient Patient { get; set; }
        public Addresses Address { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Addresses> Addresses { get; set; }

    }
}