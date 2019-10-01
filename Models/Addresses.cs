using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class Addresses
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AddressesId { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Clinic>  Clinics { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}