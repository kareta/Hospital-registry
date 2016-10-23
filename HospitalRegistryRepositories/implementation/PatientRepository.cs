using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository() : base(new HospitalRegistryContext()) {}
    }
}
