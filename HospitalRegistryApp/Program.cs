using System.Collections.Generic;
using AutoMapper;
using HospitalRegistryControllers;
using HospitalRegistryServices.Models;
using Ninject;

namespace HospitalRegistryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HospitalRegistryServices.Models.Patient, HospitalRegistryData.Entities.Patient>();
                cfg.CreateMap<HospitalRegistryData.Entities.Patient, HospitalRegistryServices.Models.Patient>();
            
            });
            IKernel kernel = new StandardKernel(new ControllerModule());
            var mainController = kernel.Get<MainController>();
            mainController.Run();
        }
    }
}
