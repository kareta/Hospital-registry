using controllers;
using HospitalRegistryServices;
using views;

namespace HospitalRegistryControllers
{
    public class PatientController : Controller
    {
        private PatientCardController patientCardController = new PatientCardController();
        private PatientSearchController patientSearchController = new PatientSearchController();

        private PatientService patientService = new PatientService();

        public PatientController() : base("Patients") { }

        public override bool RunChoice(string choice)
        {
            var exit = false;
            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Delete();
                    break;
                case "3":
                    Update();
                    break;
                case "4":
                    All();
                    break;
                case "5":
                    patientCardController.Run();
                    break;
                case "6":
                    patientSearchController.Run();
                    break;
                case "7":
                    exit = true;
                    break;
            }
            return exit;
        }

        public void Add()
        {
            View view = new View("Patients Add");
            var data = view.Run();
            patientService.SavePatientFromString(data);
        }

        public void Delete()
        {
            View view = new View("Patients Delete");
            var data = view.Run();
            var id = int.Parse(data);
            patientService.RemovePatient(id);
        }

        public void Update()
        {
            View view = new View("Patients Update");
            view.Run();
        }

        public void All()
        {
            View view = new View("Patients All");
            var data = patientService.AllPatientsToString();
            view.Run(data);
        }
    }
}
