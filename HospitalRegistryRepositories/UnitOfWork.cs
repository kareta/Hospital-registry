using System;
using System.Data.Entity;
using HospitalRegistryRepositories.implementation;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryRepositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed;

        private DbContext context;
        private IDoctorRepository doctorRepository;
        private IPatientCardRecordRepository patientCardRecordRepository;
        private IPatientRepository patientRepository;
        private IReceptionRepository receptionRepository;
        private ISpecializationRepository specializationRepository;

        public UnitOfWork(DbContext dbContext)
        {
            context = dbContext;
        }

        public IDoctorRepository DoctorRepository =>
            doctorRepository ?? (doctorRepository = new DoctorRepository(context));

        public IPatientCardRecordRepository PatientCardRecordRepository =>
            patientCardRecordRepository ?? (patientCardRecordRepository = new PatientCardRecordRepository(context));

        public IPatientRepository PatientRepository =>
            patientRepository ?? (patientRepository = new PatientRepository(context));

        public IReceptionRepository ReceptionRepository =>
            receptionRepository ?? (receptionRepository = new ReceptionRepository(context));

        public ISpecializationRepository SpecializationRepository =>
            specializationRepository ?? (specializationRepository = new SpecializationRepository(context));

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
