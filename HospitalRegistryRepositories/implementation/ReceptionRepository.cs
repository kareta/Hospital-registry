using System.Data.Entity;
using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;
using Repositories;

namespace HospitalRegistryRepositories.implementation
{
    public class ReceptionRepository : Repository<Reception>, IReceptionRepository
    {
        public ReceptionRepository(DbContext context) : base(context) { }
    }
}
