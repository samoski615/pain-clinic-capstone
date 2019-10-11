using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Display(Name = "Prescription Name")]
        public string RxName { get; set; }

        [Display(Name = "Strength")]
        public string RxStrength { get; set; }

        [Display(Name = "Dose")]
        public string RxDose { get; set; }

        [ForeignKey("Patient")]
        [HiddenInput(DisplayValue = false)]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}