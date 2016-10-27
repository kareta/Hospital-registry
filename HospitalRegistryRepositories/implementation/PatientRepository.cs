using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;
using Repositories;

namespace HospitalRegistryRepositories.implementation
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository() : base(new HospitalRegistryContext()) {}
    }
}
