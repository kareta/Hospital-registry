using controllers;

namespace HospitalRegistryControllers
{
    public class SpecializationsController : Controller
    {
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

        }

        public void Delete()
        {

        }

        public void Update()
        {

        }

        public void All()
        {

        }
    }
}
