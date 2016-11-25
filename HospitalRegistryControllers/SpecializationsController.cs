using controllers;
using views;
using HospitalRegistryServices;

namespace HospitalRegistryControllers
{
    public class SpecializationsController : Controller
    {
        private SpecializationService specializationService = new SpecializationService();

        public SpecializationsController() : base("Specializations") {}

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
            var view = new View("Specialization Add");
            var data = view.Run();
            specializationService.SaveSpecializationFromString(data);
        }

        public void Delete()
        {
            var view = new View("Specialization Delete");
            var idString = view.Run();
            int id;

            if (int.TryParse(idString, out id))
            {
                specializationService.RemoveSpecialization(id);
            }
        }

        public void Update()
        {
            var view = new View("Update Select Specialization");

            var idString = view.Run();
            int id;

            if (!int.TryParse(idString, out id))
            {
                return;
            }

            var selectOperationView = new View("Specialization. Select What To Update");
            var selectedOperation = selectOperationView.Run();

            switch (selectedOperation)
            {
                case "1":
                    UpdateTitle(id);
                    break;
                case "2":
                    UpdateDescription(id);
                    break;
            }
        }

        public void UpdateTitle(int id)
        {
            var view = new View("Update Specialization Title");
            var title = view.Run();
            specializationService.UpdateSpecializationTitle(id, title);
        }

        public void UpdateDescription(int id)
        {
            var view = new View("Update Specialization Description");
            var description = view.Run();
            specializationService.UpdateSpecializationDescription(id, description);
        }

        public void All()
        {
            var view = new View("Specialization All");
            var data = specializationService.AllSpecializationsToString();
            view.Run(data);
        }
    }
}
