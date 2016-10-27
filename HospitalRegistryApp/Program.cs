using HospitalRegistryControllers;

namespace HospitalRegistryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainController = new MainController();
            mainController.Run();
        }
    }
}
