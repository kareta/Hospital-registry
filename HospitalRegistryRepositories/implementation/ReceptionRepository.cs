using HospitalRegistryData;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories.implementation
{
    public class ReceptionRepository : Repository<Reception>, IReceptionRepository
    {
        public ReceptionRepository() : base(new HospitalRegistryContext()) {}
    }
}
