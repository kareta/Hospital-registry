using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistryServices.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual List<Reception> Reception { get; set; }

        public virtual int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
