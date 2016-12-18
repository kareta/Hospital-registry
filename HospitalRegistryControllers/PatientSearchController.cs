using controllers;
using HospitalRegistryServices;
using views;

namespace HospitalRegistryControllers
{
    public class PatientSearchController : Controller
    {
        private PatientService patientService;

        public PatientSearchController(PatientService patientService) : base("Patients Search")
        {
            this.patientService = patientService;
        }

        public override bool RunChoice(string choice)
        {
            var exit = false;
            switch (choice)
            {
                case "1":
                    SearchByName();
                    break;
                case "2":
                    SearchBySurname();
                    break;
                case "3":
                    SearchByNameSurname();
                    break;
                case "4":
                    SearchById();
                    break;
                case "5":
                    exit = true;
                    break;
            }
            return exit;
        }

        public void SearchByName()
        {
            var view = new View("Patients Search By Name");
            var name = view.Run();
            var viewAll = new View("Patients All");
            var data = patientService.ByNameToString(name);
            viewAll.Run(data);
        }

        public void SearchBySurname()
        {
            var view = new View("Patients Search By Surname");
            var surname = view.Run();
            var viewAll = new View("Patients All");
            var data = patientService.BySurnameToString(surname);
            viewAll.Run(data);
        }

        public void SearchByNameSurname()
        {
            var view = new View("Patients Search By Name and Surname");
            var nameSurname = view.Run();
            var viewAll = new View("Patients All");
            var data = patientService.ByNameSurnameToString(nameSurname);
            viewAll.Run(data);
        }

        public void SearchById()
        {
            var view = new View("Patients Search By Id");
            var idString = view.Run();
            int id;

            if (!int.TryParse(idString, out id))
            {
                return;
            }

            var viewAll = new View("Patients All");
            var data = patientService.ByIdToString(id);
            viewAll.Run(data);
        }
    }
}
