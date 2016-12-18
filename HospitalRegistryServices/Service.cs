using HospitalRegistryRepositories;

namespace HospitalRegistryServices
{
    public abstract class Service
    {
        protected IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
           UnitOfWork = unitOfWork;
        }
    }
}
