using System.Data.Entity;
using HospitalRegistryData.Entities;

namespace HospitalRegistryData
{
    public class HospitalRegistryContext : DbContext
    {
        public HospitalRegistryContext(string path) : base(path) { }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Reception> Receptions { get; set; }
        public virtual DbSet<PatientCardRecord> PatientCardRecord { get; set; }
    }
}
