
using System.Collections.Generic;

namespace HospitalRegistryData
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
