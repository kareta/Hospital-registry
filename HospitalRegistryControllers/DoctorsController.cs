
using controllers;
using HospitalRegistryServices;
using Ninject;
using views;

namespace HospitalRegistryControllers
{
    public class DoctorsController : Controller
    {
        private DoctorSearchController doctorSearchController;
        private DoctorService doctorService;

        public DoctorsController(
            [Named("DoctorSearchController")] Controller doctorSearchController,
            DoctorService doctorService
        ) : base("Doctors")
        {
            this.doctorService = doctorService;
        }

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
                    doctorSearchController.Run();
                    break;
                case "6":
                    exit = true;
                    break;
            }
            return exit;
        }

        public void Add()
        {
            var view = new View("Doctor Add");
            var data = view.Run();
            doctorService.SaveDoctorFromString(data);
        }

        public void Delete()
        {
            var view = new View("Doctor Delete");
            var idString = view.Run();
            int id;

            if (int.TryParse(idString, out id))
            {
                doctorService.RemoveDoctor(id);
            }
        }

        public void Update()
        {
            var view = new View("Update Select Doctor");

            var idString = view.Run();
            int id;

            if (!int.TryParse(idString, out id))
            {
                return;
            }

            var selectOperationView = new View("Doctor. Select What To Update");
            var selectedOperation = selectOperationView.Run();

            switch (selectedOperation)
            {
                case "1":
                    UpdateName(id);
                    break;
                case "2":
                    UpdateSurname(id);
                    break;
                case "3":
                    UpdateSpecialization(id);
                    break;
            }
        }

        public void UpdateName(int id)
        {
            var view = new View("Update Doctor Name");
            var name = view.Run();
            doctorService.UpdateDoctorName(id, name);
        }

        public void UpdateSurname(int id)
        {
            var view = new View("Update Doctor Surname");
            var surname = view.Run();
            doctorService.UpdateDoctorSurname(id, surname);
        }

        public void UpdateSpecialization(int id)
        {
            var view = new View("Update Specialization Id");
            var specializationIdString = view.Run();
            int specializationId;

            if (!int.TryParse(specializationIdString, out specializationId))
            {
                return;
            }

            doctorService.UpdateDoctorSpecialization(id, specializationId);
        }

        public void All()
        {
            var view = new View("Doctor All");
            var data = doctorService.AllDoctorsToString();
            view.Run(data);
        }
    }
}
