using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;

namespace HospitalRegistryServices
{
    public class PatientCardService
    {
        private readonly PatientCardRecordRepository _patientCardRecordRepository
            = new PatientCardRecordRepository();

        private readonly ReceptionRepository _receptionRepository
            = new ReceptionRepository();

        public void StoreRecordFromString(string record)
        {
            _patientCardRecordRepository.Add(RecordFromString(record));
        }

        public PatientCardRecord RecordFromString(string record)
        {
            var splittedRecord = record.Split('.');
            var receptionId = int.Parse(splittedRecord[0]);
            var symptoms = splittedRecord[1];
            var diagnosis = splittedRecord[2];
            var prescription = splittedRecord[3];

            var reception = _receptionRepository.Get(receptionId);

            return new PatientCardRecord
            {
                Symptoms = symptoms, 
                Diagnosis = diagnosis,
                Prescription = prescription,
                Reception = reception
            };
        }
    }
}
