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
            if (splittedData.Length != 2)
            {
                return null;
            }

            var name = splittedData[0];
            var surname = splittedData[1];

            return new Patient {Name = name, Surname = surname};
        }

        public void SavePatientFromString(string patientData)
        {
            var patient = PatientFromString(patientData);
            if (patient != null)
            {
                patientRepository.Add(patient);
            }
            
        }

        public void UpdatePatientName(int id, string name)
        {
            var patient = patientRepository.Get(id);
            patient.Name = name;
            patientRepository.Update();
        }

        public void UpdatePatientSurname(int id, string surname)
        {
            var patient = patientRepository.Get(id);
            patient.Surname = surname;
            patientRepository.Update();
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
