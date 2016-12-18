using controllers;
using HospitalRegistryControllers;
using HospitalRegistryData;
using HospitalRegistryRepositories;
using Ninject.Modules;

namespace HospitalRegistryApp
{
    public class ControllerModule : NinjectModule
    {
        private static readonly string dbPath =
            "AttachDbFilename = C:\\Users\\vitya\\myprojects\\HospitalRegistry\\HospitalRegistryApp\\bin\\Debug\\registry.mdf;";
        private static readonly string connectionString =
            $"Data Source=(localdb)\\MSSQLLocalDB; {dbPath} Initial Catalog=registry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public override void Load()
        {
            Bind<Controller>().To<PatientController>().Named("PatientController");
            Bind<Controller>().To<DoctorsController>().Named("DoctorsController");
            Bind<Controller>().To<ScheduleController>().Named("ScheduleController");
            Bind<Controller>().To<SpecializationsController>().Named("SpecializationsController");
            Bind<Controller>().To<DoctorSearchController>().Named("DoctorSearchController");
            Bind<Controller>().To<PatientCardController>().Named("PatientCardController");
            Bind<Controller>().To<PatientSearchController>().Named("PatientSearchController");

            Bind<IUnitOfWork>().
                To<UnitOfWork>().
                WithConstructorArgument("dbContext", new HospitalRegistryContext(connectionString));
        }
    }
}
