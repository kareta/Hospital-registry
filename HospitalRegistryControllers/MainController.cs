using controllers;

namespace HospitalRegistryControllers
{
    public class MainController : Controller
    {
        private DoctorsController doctorsController = new DoctorsController();
        private PatientController patientController = new PatientController();
        private ScheduleController scheduleController = new ScheduleController();
        private SpecializationsController specializationsController = new SpecializationsController();

        public MainController() : base("Main") { }

        public override bool RunChoice(string choice)
        {
            var exit = false;
            switch (choice)
            {
                case "1":
                    doctorsController.Run();
                    break;
                case "2":
                    specializationsController.Run();
                    break;
                case "3":
                    patientController.Run();
                    break;
                case "4":
                    scheduleController.Run();
                    break;
                case "5":
                    exit = true;
                    break;
            }
            return exit;
        }

        
    }
}