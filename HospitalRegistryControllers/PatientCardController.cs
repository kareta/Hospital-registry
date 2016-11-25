using controllers;
using HospitalRegistryServices;
using views;

namespace HospitalRegistryControllers
{
    public class PatientCardController : Controller
    {
        private PatientCardService patientCardService = new PatientCardService();

        public PatientCardController() : base("Patient Card") {}

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
                    exit = true;
                    break;
            }
            return exit;
        }

        public void Add()
        {
            var view = new View("Add Card Record");
            var data = view.Run();
            patientCardService.StoreRecordFromString(data);
        }

        public void Delete()
        {

        }

        public void Update()
        {

        }

        public void All()
        {
            var view = new View("All Card Records");
            var data = patientCardService.AllRecordsToString();
            view.Run(data);
        }
    }
}
