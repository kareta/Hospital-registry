using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class ReceptionRepository : Repository<Reception>, IReceptionRepository
    {
        public ReceptionRepository() : base(new HospitalRegistryContext()) {}
    }
}
