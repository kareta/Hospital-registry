﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HospitalRegistryRepositories;
using HospitalRegistryRepositories.interfaces;
using HospitalRegistryServices.Models;

namespace HospitalRegistryServices
{
    public class PatientService : Service
    {
        private IPatientRepository PatientRepository;

        public PatientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            PatientRepository = unitOfWork.PatientRepository;
        }

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
            if (patient == null) return;

            var patientEntity = Mapper.Map<HospitalRegistryData.Entities.Patient>(patient);
            PatientRepository.Add(patientEntity);
        }

        public void UpdatePatientName(int id, string name)
        {
            var patient = PatientRepository.Get(id);

            if (patient == null)
            {
                return;
            }

            patient.Name = name;
            PatientRepository.Update();
        }

        public void UpdatePatientSurname(int id, string surname)
        {
            var patient = PatientRepository.Get(id);
            if (patient == null)
            {
                return;
            }
            patient.Surname = surname;
            PatientRepository.Update();
        }

        public void RemovePatient(int id)
        {
            var patient = PatientRepository.Get(id);
            if (patient == null)
            {
                return;
            }
            PatientRepository.Remove(patient);
        }

        public string AllPatientsToString()
        {
            var patientsEntities = PatientRepository.GetAll();
            var patients = Mapper.Map<List<Patient>>(patientsEntities);

            return PatientsToString(patients);
        }

        public string ByNameToString(string name)
        {
            var patientsEntities = PatientRepository.Find(p => p.Name == name);
            var patients = Mapper.Map<List<Patient>>(patientsEntities);

            return PatientsToString(patients);
        }

        public string BySurnameToString(string surname)
        {
            var patientsEntities = PatientRepository.Find(p => p.Surname == surname);
            var patients = Mapper.Map<List<Patient>>(patientsEntities);

            return PatientsToString(patients);
        }

        public string ByNameSurnameToString(string data)
        {
            var splittedData = data.Split(' ');
            if (splittedData.Length != 2)
            {
                return null;
            }

            var name = splittedData[0];
            var surname = splittedData[1];

            var patientsEntities = PatientRepository.Find(p => p.Surname == surname && p.Name == name);
            var patients = Mapper.Map<List<Patient>>(patientsEntities);

            return PatientsToString(patients);
        }

        public string ByIdToString(int id)
        {
            var patientsEntities = PatientRepository.Find(p => p.PatientId == id);
            var patients = Mapper.Map<List<Patient>>(patientsEntities);

            return PatientsToString(patients);
        }

        public string PatientsToString(List<Patient> patients)
        {
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
