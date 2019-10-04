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

        [ForeignKey("Addresses")]
        [HiddenInput(DisplayValue = false)]
        public int? AddressesId { get; set; }
        public Addresses Addresses { get; set; }

        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; }

        // public virtual ICollection<ClinicDirectory> ClinicDirectories { get; set; }


        //[ForeignKey("Provider")]
        //[HiddenInput(DisplayValue = false)]
        //public int ProviderId { get; set; }
        //public Provider Provider { get; set; }

        //[ForeignKey("Patient")]
        //[HiddenInput(DisplayValue = false)]
        //public int PatientId { get; set; }
        //public Patient Patient { get; set; }

        //public virtual ICollection<Provider> Providers { get; set; }
    }
}
