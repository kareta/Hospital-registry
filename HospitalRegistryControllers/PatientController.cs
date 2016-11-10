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
            var view = new View("Patients Add");
            var data = view.Run();
            patientService.SavePatientFromString(data);
        }

        public void Delete()
        {
            var view = new View("Patients Delete");
            var idString = view.Run();
            int id;

            if (int.TryParse(idString, out id))
            {
                patientService.RemovePatient(id);
            }
        }

        public void Update()
        {
            var view = new View("Update Select Patient");
             
            var idString  = view.Run();
            int id;

            if (!int.TryParse(idString, out id))
            {
                return;
            }

            var selectOperationView = new View("Patients. Select What To Update");
            var selectedOperation = selectOperationView.Run();

            switch (selectedOperation)
            {
                case "1":
                    UpdateName(id);
                    break;
                case "2":
                    UpdateSurname(id);
                    break;
            }
        }

        public void UpdateName(int id)
        {
            var view = new View("Update Patient Name");
            var name = view.Run();
            patientService.UpdatePatientName(id, name);
        }

        public void UpdateSurname(int id)
        {
            var view = new View("Update Patient Surname");
            var surname = view.Run();
            patientService.UpdatePatientSurname(id, surname);
        }

        public void All()
        {
            var view = new View("Patients All");
            var data = patientService.AllPatientsToString();
            view.Run(data);
        }
    }
}
