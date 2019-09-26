using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; }  

        [Display(Name = "Addresses")]
        [Required]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State Abbriviation")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        [Required]
        public string Zipcode { get; set; }
    }
}