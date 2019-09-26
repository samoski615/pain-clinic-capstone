using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class PatientProviderDirectory
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int DirectoryId { get; set; }

        [ForeignKey("Patient")]
        [HiddenInput(DisplayValue = false)]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Provider")]
        [HiddenInput(DisplayValue = false)]
        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}