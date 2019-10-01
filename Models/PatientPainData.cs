using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class PatientPainData
    {
        //Junction Table to hold Patients and DailyPainJournal info
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int PatientPainDataId { get; set; }

        public int DailyPainJournalId { get; set; }
        public virtual DailyPainJournal DailyPainJournal { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

    }
}