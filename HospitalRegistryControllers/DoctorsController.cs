﻿
using controllers;

namespace HospitalRegistryControllers
{
    public class DoctorsController : Controller
    {
        private DoctorSearchController doctorSearchController = new DoctorSearchController();

        public DoctorsController() : base("Doctors") { }

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

        public void Search()
        {

        }
    }
}
