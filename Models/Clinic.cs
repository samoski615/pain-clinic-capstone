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



        //public Clinic()
        //{
        //    this.Name = "Placeholder Until I Come Up With A Good Name";
        //    this.Address = "959 W Mayfair Rd";
        //    this.City = "Milwaukee";
        //    this.State = "WI";
        //    this.Zipcode = "53226";
        //}
    }
}