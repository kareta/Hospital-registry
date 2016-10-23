using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;

namespace HospitalRegistryServices
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();

        public void AddPatient(string name, string surname)
        {
            var patient = new Patient {Name = name, Surname = surname};
            patientRepository.Add(patient);
        }

        public Patient PatientFromString(string patientData)
        {
            var splittedData = patientData.Split(' ');
            var name = splittedData[0];
            var surname = splittedData[1];

            return new Patient {Name = name, Surname = surname};
        }

        public void SavePatientFromString(string patientData)
        {
            var splittedData = patientData.Split(' ');
            var name = splittedData[0];
            var surname = splittedData[1];

            var patient = new Patient { Name = name, Surname = surname };
            patientRepository.Add(patient);
        }

        public void RemovePatient(int id)
        {
            var patient = patientRepository.Get(id);
            patientRepository.Remove(patient);
        }
    }
}
