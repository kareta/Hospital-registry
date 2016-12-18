
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;
using System;
using System.Text;
using HospitalRegistryRepositories;
using HospitalRegistryRepositories.interfaces;

namespace HospitalRegistryServices
{
    public class SpecializationService : Service
    {
        private ISpecializationRepository SpecializationRepository;

        public SpecializationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            SpecializationRepository = unitOfWork.SpecializationRepository;
        }

        public Specialization SpecializationFromString(string specializationData)
        {
            specializationData = specializationData.Trim(']', '[');
            var splittedData = specializationData.Split(
                new string[] { "] [", " [", " ]" }, StringSplitOptions.None
            );
            if (splittedData.Length != 2)
            {
                return null;
            }

            var title = splittedData[0];
            var description = splittedData[1];

            return new Specialization { Title = title, Description = description };
        }

        public void SaveSpecializationFromString(string specializationData)
        {
            var specialization = SpecializationFromString(specializationData);
            if (specialization != null)
            {
                SpecializationRepository.Add(specialization);
            }
        }

        public void UpdateSpecializationTitle(int id, string title)
        {
            var specialization = SpecializationRepository.Get(id);
            specialization.Title = title;
            SpecializationRepository.Update();
        }

        public void UpdateSpecializationDescription(int id, string description)
        {
            var specialization = SpecializationRepository.Get(id);
            specialization.Description = description;
            SpecializationRepository.Update();
        }

        public void RemoveSpecialization(int id)
        {
            var specialization = SpecializationRepository.Get(id);
            SpecializationRepository.Remove(specialization);
        }

        public string AllSpecializationsToString()
        {
            var specializations = SpecializationRepository.GetAll();
            var builder = new StringBuilder();

            foreach (var specialization in specializations)
            {
                builder.AppendLine("id: " + specialization.SpecializationId);
                builder.AppendLine("title: " + specialization.Title);
                builder.AppendLine("description: " + specialization.Description + "\n");
            }
            return builder.ToString();
        }
    }
}