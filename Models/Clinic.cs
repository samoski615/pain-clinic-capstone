using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class Clinic
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ClinicId { get; set; }

        //[ForeignKey("Provider")]
        //public int ProviderId { get; set; }
        //public Provider Provider { get; set; }

        //[ForeignKey("Patient")]
        //[HiddenInput(DisplayValue = false)]
        //public int PatientId { get; set; }
        //public Patient Patient { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        public Clinic()
        {
            this.Name = "Placeholder Until I Come Up With A Good Name";
            this.Address = "959 W Mayfair Rd";
            this.City = "Milwaukee";
            this.State = "WI";
            this.Zipcode = "53226";
        }
    }
}