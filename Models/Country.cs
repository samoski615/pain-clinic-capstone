using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainClinic.Models
{
    public class Country
    {
        //#region  
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string MapReference { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeLong { get; set; }
        //#endregion
    }
}