using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories
{
    public interface IUnitOfWork
    {
        IDoctorRepository DoctorRepository { get; }
        IPatientCardRecordRepository PatientCardRecordRepository { get; }
        IPatientRepository PatientRepository { get; }
        IReceptionRepository ReceptionRepository { get; }
        ISpecializationRepository SpecializationRepository { get; }
    }
}
