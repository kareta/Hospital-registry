using controllers;

namespace HospitalRegistryControllers
{
    public class PatientSearchController : Controller
    {
        public PatientSearchController() : base("Patiens Search") {}

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
        }

        public void SearchBySurname()
        {
        }

        public void SearchByNameSurname()
        {
        }

        public void SearchById()
        {
        }
    }
}
