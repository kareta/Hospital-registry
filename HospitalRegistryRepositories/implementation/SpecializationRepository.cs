using HospitalRegistryData;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository() : base(new HospitalRegistryContext()) { }
    }
}
