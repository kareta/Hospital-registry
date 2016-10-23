
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalRegistryData
{
    public class Reception
    {
        [Key, ForeignKey("PatientCardRecord")]
        public int ReceptionId { get; set; }
        public DateTime Date { get; set; }
        public int Room { get; set; }

        public virtual int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public virtual int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public virtual PatientCardRecord PatientCardRecord { get; set; }
    }
}
