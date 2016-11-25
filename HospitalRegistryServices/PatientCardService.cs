using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;
using System;
using System.Text;

namespace HospitalRegistryServices
{
    public class PatientCardService
    {
        private readonly PatientCardRecordRepository patientCardRecordRepository
            = new PatientCardRecordRepository();

        private readonly ReceptionRepository receptionRepository
            = new ReceptionRepository();

        public void StoreRecordFromString(string recordString)
        {
            var record = RecordFromString(recordString);
            if (record != null)
            {
                patientCardRecordRepository.Add(record);
            }    
        }

        public PatientCardRecord RecordFromString(string record)
        {
            record = record.Trim(']', '[');
            var splittedRecord = record.Split(
                new string[] { "] [" }, StringSplitOptions.None
            );

            var receptionId = int.Parse(splittedRecord[0]);
            var symptoms = splittedRecord[1];
            var diagnosis = splittedRecord[2];
            var prescription = splittedRecord[3];

            var reception = receptionRepository.Get(receptionId);

            if (reception == null)
            {
                return null;
            }

            return new PatientCardRecord
            {
                Symptoms = symptoms, 
                Diagnosis = diagnosis,
                Prescription = prescription,
                Reception = reception
            };
        }

        public string AllRecordsToString()
        {
            var records = patientCardRecordRepository.GetAll();
            var builder = new StringBuilder();

            foreach (var record in records)
            {
                var doctorName = record.Reception.Doctor.Name;
                var doctorSurname = record.Reception.Doctor.Surname;

                builder.AppendLine("Doctor name: " + doctorName);
                builder.AppendLine("Doctor surname: " + doctorSurname);
                builder.AppendLine("Symptoms: " + record.Symptoms);
                builder.AppendLine("Diagnosis:" + record.Diagnosis);
                builder.AppendLine(record.Prescription + "\n");
            }
            return builder.ToString();
        }
    }
}
