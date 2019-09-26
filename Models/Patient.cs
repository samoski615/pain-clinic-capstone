using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class Patient
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid PatientId { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }

        [ForeignKey("Clinic")]
        [HiddenInput(DisplayValue = false)]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } 

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        //[Display(Name = "Email Address")]
        //public string EmailAddress { get; set; }

        //[Display(Name = "Phone Number")]
        //public string PhoneNumber { get; set; }

        [Display(Name ="Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State Abbriviation")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        [Required]
        public string Zipcode { get; set; }

        [ForeignKey("ApplicationUser")]
        [HiddenInput(DisplayValue = false)]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

}