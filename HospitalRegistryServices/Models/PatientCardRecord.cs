﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistryServices.Models
{
    public class PatientCardRecord
    {
        public int PatientCardRecordId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }

        public virtual Reception Reception { get; set; }
    }
}
