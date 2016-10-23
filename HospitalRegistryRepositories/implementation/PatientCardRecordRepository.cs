using HospitalRegistryData;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class PatientCardRecordRepository : Repository<PatientCardRecord>, IPatientCardRecordRepository
    {
        public PatientCardRecordRepository() : base(new HospitalRegistryContext()) { }
    }
}
