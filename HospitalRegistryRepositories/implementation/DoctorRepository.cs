using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository() : base(new HospitalRegistryContext()) {}
    }
}

