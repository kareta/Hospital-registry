using HospitalRegistryData;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository() : base(new HospitalRegistryContext()) {}
    }
}
