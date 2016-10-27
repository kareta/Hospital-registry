using System.ComponentModel;
using views;

namespace controllers
{
    public abstract class Controller
    {
        private IView view;

        protected Controller(string viewName)
        {
            view = new View(viewName);
        }

        public void Run()
        {
            var exit = false;
            while (!exit)
            {
                var choice = view.Run();
                exit = RunChoice(choice);
            }
        }

        public abstract bool RunChoice(string choice);
    }
}
