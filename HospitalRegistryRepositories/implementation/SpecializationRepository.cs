using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;
using Repositories;

namespace HospitalRegistryRepositories.implementation
{
    class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository() : base(new HospitalRegistryContext()) { }
    }
}
