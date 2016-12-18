

using System.Collections.Generic;

namespace HospitalRegistryServices.Models
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<Doctor> Doctor { get; set; }
    }
}
