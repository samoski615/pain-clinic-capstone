using PainClinic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class Provider
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderId { get; set; }

        public virtual ICollection<ClinicDirectory> ClinicDirectories { get; set; }
        public PatientDataViewModel PatientDataVM { get; set; }

        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Request Received")]
        public bool? RxReceived { get; set; }

        [Display(Name = "Balance")]
        public double? PatientBalance { get; set; }

        [ForeignKey("ApplicationUser")]
        [HiddenInput(DisplayValue = false)]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("Patient")]
        //[HiddenInput(DisplayValue = false)]
        //public int? PatientId { get; set; }
        //public Patient Patient { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public int? ClinicId { get; set; }
        //public Clinic Clinic { get; set; }

        //public virtual ICollection<Patient> Patients { get; set; }

    }
}