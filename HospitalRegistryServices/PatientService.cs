using System.Text;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;

namespace HospitalRegistryServices
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();

        public Patient PatientFromString(string patientData)
        {
            var splittedData = patientData.Split(' ');
            var name = splittedData[0];
            var surname = splittedData[1];

            return new Patient {Name = name, Surname = surname};
        }

        public void SavePatientFromString(string patientData)
        {
            patientRepository.Add(PatientFromString(patientData));
        }

        public void UpdatePatientFromString(string patientData)
        {

        }

        public void RemovePatient(int id)
        {
            var patient = patientRepository.Get(id);
            patientRepository.Remove(patient);
        }

        public string AllPatientsToString()
        {
            var patients = patientRepository.GetAll();
            var builder = new StringBuilder();

            foreach (var patient in patients)
            {
                builder.Append(patient.PatientId + " ");
                builder.Append(patient.Name + " ");
                builder.Append(patient.Surname + "\n");
            }
            return builder.ToString();
        }
    }
}
