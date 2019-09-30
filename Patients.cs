namespace PainClinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Patients
    {
        [Key]
        public int PatientId { get; set; }

        public int? AddressesId { get; set; }

        public int? DailyLogId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool RxReceived { get; set; }

        [StringLength(128)]
        public string ApplicationId { get; set; }
    }
}
