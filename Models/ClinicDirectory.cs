using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public partial class ClinicDirectory
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ClinicDirectoryId { get; set; }

        //public int ProviderId { get; set; }
        //public virtual Provider Provider { get; set; }

        //public int PatientId { get; set; }
        //public virtual Patient Patient { get; set; }

        //public int ClinicId { get; set; }
        //public virtual Clinic Clinic { get; set; }

    }
}