using System.Collections.Generic;

namespace HospitalRegistryData.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual List<Reception> Reception { get; set; }
    }
}
