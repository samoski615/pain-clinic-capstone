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
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        public virtual ICollection<DailyPainJournal> DailyLogs { get; set; }
        public virtual ICollection<ClinicDirectory> ClinicDirectories { get; set; }
        //public virtual ICollection<Addresses> Addresses { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Request Received")]
        [HiddenInput(DisplayValue = false)]
        public bool? RxReceived { get; set; }

        [Display(Name = "Balance")]
        public double? PatientBalance { get; set; }

        [ForeignKey("ApplicationUser")]
        [HiddenInput(DisplayValue = false)]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("Addresses")]
        //[HiddenInput(DisplayValue = false)]
        public int? AddressesId { get; set; }
        public Addresses Addresses { get; set; }

        //[ForeignKey("Provider")]
        //[InverseProperty("Provider")]
        //[HiddenInput(DisplayValue = false)]
        //public int? ProviderId { get; set; }
        //public Provider Provider { get; set; }

        //[ForeignKey("Clinic")]
        //[InverseProperty("Clinic")]
        //[HiddenInput(DisplayValue = false)]
        //public int? ClinicId { get; set; }
        //public Clinic Clinic { get; set; }

        //[ForeignKey("DailyLog")]
        //[InverseProperty("DailyLog")]
        //[HiddenInput(DisplayValue = false)]
        //public int? DailyLog { get; set; }
        //public DailyLog DailyLogs { get; set; }


        //public virtual ICollection<Provider> Providers { get; set; }

    }

}