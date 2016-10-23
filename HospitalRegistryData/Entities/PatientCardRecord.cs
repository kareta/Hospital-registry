using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalRegistryData.Entities
{
    public class PatientCardRecord
    {
        [Key, ForeignKey("Reception")]
        public int PatientCardRecordId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }

        public virtual Reception Reception { get; set; }
    }
}
