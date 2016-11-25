
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.implementation;
using System;
using System.Text;

namespace HospitalRegistryServices
{
    public class SpecializationService
    {
        private SpecializationRepository specializationRepository = new SpecializationRepository();

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
                specializationRepository.Add(specialization);
            }
        }

        public void UpdateSpecializationTitle(int id, string title)
        {
            var specialization = specializationRepository.Get(id);
            specialization.Title = title;
            specializationRepository.Update();
        }

        public void UpdateSpecializationDescription(int id, string description)
        {
            var specialization = specializationRepository.Get(id);
            specialization.Description = description;
            specializationRepository.Update();
        }

        public void RemoveSpecialization(int id)
        {
            var specialization = specializationRepository.Get(id);
            specializationRepository.Remove(specialization);
        }

        public string AllSpecializationsToString()
        {
            var specializations = specializationRepository.GetAll();
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