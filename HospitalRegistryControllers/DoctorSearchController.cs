using controllers;

namespace HospitalRegistryControllers
{
    public class DoctorSearchController : Controller
    {
        public DoctorSearchController() : base("Doctors Search") {}

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
                    SearchBySpecialization();
                    break;
                case "6":
                    exit = true;
                    break;
            }
            return exit;
        }

        public void SearchBySpecialization()
        {
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
