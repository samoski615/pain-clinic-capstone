﻿using System;
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
        public ICollection<Provider> Providers { get; set; }

        [ForeignKey("Clinic")]
        [HiddenInput(DisplayValue = false)]
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        [ForeignKey("Addresses")]
        [HiddenInput(DisplayValue = false)]
        public int? AddressesId { get; set; }
        public Addresses Addresses { get; set; }

        [ForeignKey("DailyLog")]
        [HiddenInput(DisplayValue = false)]
        public int? DailyLogId { get; set; }
        public DailyLog DailyLog { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Request Received")]
        public bool RxReceived { get; set; }

        [ForeignKey("ApplicationUser")]
        [HiddenInput(DisplayValue = false)]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

}