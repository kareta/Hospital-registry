using HospitalRegistryData.Entities;
using System.Text;
using HospitalRegistryRepositories;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryServices
{
    public class DoctorService : Service
    {
        private IDoctorRepository DoctorRepository;
        private ISpecializationRepository SpecializationRepository;

        public DoctorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            DoctorRepository = unitOfWork.DoctorRepository;
            SpecializationRepository = unitOfWork.SpecializationRepository;
        }

        public Doctor DoctorFromString(string doctorData)
        {
            var splittedData = doctorData.Split(' ');
            if (splittedData.Length != 3)
            {
                return null;
            }

            var name = splittedData[0];
            var surname = splittedData[1];
            var specializationId = int.Parse(splittedData[2]);

            if (SpecializationRepository.Get(specializationId) == null)
            {
                return null;
            }

            return new Doctor {
                Name = name, Surname = surname, SpecializationId = specializationId
            };
        }

        public void SaveDoctorFromString(string patientData)
        {
            var doctor = DoctorFromString(patientData);
            if (doctor != null)
            {
                DoctorRepository.Add(doctor);
            }

        }

        public void UpdateDoctorName(int id, string name)
        {
            var doctor = DoctorRepository.Get(id);
            if (doctor == null)
            {
                return;
            }
            doctor.Name = name;
            DoctorRepository.Update();
        }

        public void UpdateDoctorSurname(int id, string surname)
        {
            var doctor = DoctorRepository.Get(id);
            if (doctor == null)
            {
                return;
            }
            doctor.Surname = surname;
            DoctorRepository.Update();
        }

        public void UpdateDoctorSpecialization(int id, int specializationId)
        {
            if (SpecializationRepository.Get(specializationId) == null)
            {
                return;
            }

            var doctor = DoctorRepository.Get(id);

            if (doctor == null)
            {
                return;
            }

            doctor.SpecializationId = specializationId;
            DoctorRepository.Update();
        }

        public void RemoveDoctor(int id)
        {
            var doctor = DoctorRepository.Get(id);
            DoctorRepository.Remove(doctor);
        }

        public string AllDoctorsToString()
        {
            var doctors = DoctorRepository.GetAll();
            var builder = new StringBuilder();

            foreach (var doctor in doctors)
            {
                builder.Append(doctor.DoctorId + " ");
                builder.Append(doctor.Name + " ");
                builder.Append(doctor.Surname + " ");
                builder.Append(doctor.Specialization.Title + "\n");
            }
            return builder.ToString();
        }
    }
}

