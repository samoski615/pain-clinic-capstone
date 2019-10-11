﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainClinic.Models.ViewModels
{
    public class PatientAcctMgmtViewModel
    {
        public Patient Patient { get; set; }
        public Addresses Address { get; set; }
        public LocationInfo LocationInfo { get; set; }
        public Provider Provider { get; set; }
        public Prescription Prescription { get; set; }
        public StripeSettings StripeSettings { get; set; }
    }
}