using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistryServices.Models
{
    public class Reception
    {
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
