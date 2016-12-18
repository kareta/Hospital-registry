using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HospitalRegistryRepositories;
using HospitalRegistryRepositories.interfaces;
using HospitalRegistryServices.Models;

namespace HospitalRegistryServices
{
    public class ReceptionService : Service
    {
        private IReceptionRepository ReceptionRepository;
        private IDoctorRepository DoctorRepository;
        private IPatientRepository PatientRepository;

        public ReceptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            ReceptionRepository = unitOfWork.ReceptionRepository;
            DoctorRepository = unitOfWork.DoctorRepository;
            PatientRepository = unitOfWork.PatientRepository;
        }

        public Reception ReceptionFromString(string specializationData)
        {
            var splittedData = specializationData.Split();
            if (splittedData.Length != 4)
            {
                return null;
            }

            var dateString = splittedData[0];
            DateTime date;
            var roomString = splittedData[1];
            int room;
            var doctorIdString = splittedData[2];
            int doctorId;
            var patientIdString = splittedData[3];
            int patientId;

            try
            {
                date = Convert.ToDateTime(dateString);
            }
            catch (FormatException)
            {
                return null;
            }

            if (!int.TryParse(roomString, out room))
            {
                return null;
            }

            if (!int.TryParse(doctorIdString, out doctorId))
            {
                return null;
            }

            if (!int.TryParse(patientIdString, out patientId))
            {
                return null;
            }

            return new Reception { Date = date, Room = room, DoctorId = doctorId, PatientId = patientId};
        }

        public void SaveReceptionFromString(string data)
        {
            var reception = ReceptionFromString(data);

            if (reception == null)
            {
                return;
            }

            var receptionEntity = Mapper.Map<HospitalRegistryData.Entities.Reception>(reception);
            ReceptionRepository.Add(receptionEntity);
        }

        public void UpdateReceptionDate(int id, string dateString)
        {
            var reception = ReceptionRepository.Get(id);

            if (reception == null)
            {
                return;
            }

            DateTime date;

            try
            {
                date = Convert.ToDateTime(dateString);
            }
            catch (FormatException)
            {
                return;
            }

            reception.Date = date;
            ReceptionRepository.Update();
        }

        public void UpdateReceptionRoom(int id, int room)
        {
            var reception = ReceptionRepository.Get(id);

            if (reception == null)
            {
                return;
            }

            reception.Room = room;
            ReceptionRepository.Update();
        }

        public void UpdateReceptionDoctor(int id, int doctorId)
        {
            var reception = ReceptionRepository.Get(id);

            if (reception == null)
            {
                return;
            }

            if (DoctorRepository.Get(id) == null)
            {
                return;
            }

            reception.DoctorId = doctorId;
            ReceptionRepository.Update();
        }

        public void UpdateReceptionPatient(int id, int patientId)
        {
            var reception = ReceptionRepository.Get(id);

            if (reception == null)
            {
                return;
            }

            if (PatientRepository.Get(id) == null)
            {
                return;
            }

            reception.PatientId = patientId;
            ReceptionRepository.Update();
        }

        public void RemoveReception(int id)
        {
            var reception = ReceptionRepository.Get(id);

            if (reception == null)
            {
                return;
            }

            ReceptionRepository.Remove(reception);
        }

        public string AllReceptionsToString()
        {

            var receptionsEntities = ReceptionRepository.GetAll();
            var receptions = Mapper.Map<List<Reception>>(receptionsEntities);
            var builder = new StringBuilder();

            foreach (var reception in receptions)
            {
                var patient = reception.Patient;
                var doctor = reception.Doctor;
                var patientString = patient.PatientId + " " + patient.Name + " " + patient.Surname;
                var doctorString = doctor.DoctorId + " " + doctor.Name + " " + doctor.Surname;

                builder.AppendLine("id: " + reception.ReceptionId);
                builder.AppendLine("date: " + reception.Date);
                builder.AppendLine("room: " + reception.Room);
                builder.AppendLine("doctor: " + doctorString);
                builder.AppendLine("patient: " + patientString + "\n");
            }
            return builder.ToString();
        }
    }
}
