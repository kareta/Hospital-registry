using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;
using Repositories;

namespace HospitalRegistryRepositories.implementation
{
    public class PatientCardRecordRepository : Repository<PatientCardRecord>, IPatientCardRecordRepository
    {
        public PatientCardRecordRepository() : base(new HospitalRegistryContext()) { }
    }
}
