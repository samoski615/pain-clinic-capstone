namespace PainClinic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Providers
    {
        [Key]
        public int ProviderId { get; set; }

        public string Prefix { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool RxReceived { get; set; }

        [StringLength(128)]
        public string ApplicationId { get; set; }
    }
}
