
using System;

namespace HospitalRegistry
{
    public class Program
    {
        public static void ManageDoctors()
        {
            var back = false;
            while (!back)
            {
                Console.WriteLine("1. Add doctor.");
                Console.WriteLine("2. Delete doctor.");
                Console.WriteLine("3. Change doctor data.");
                Console.WriteLine("4. All doctors.");
                Console.WriteLine("5. Back.");

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:
                            back = true;
                            break;

                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        public static void ManagePatients()
        {

        }

        public static void ManageSchedule()
        {

        }

        public static void Search()
        {

        }

        public static void Main(string[] args)
        {

            var close = false;
            while (!close)
            {
                Console.WriteLine("1. Manage doctors.");
                Console.WriteLine("2. Manage patients.");
                Console.WriteLine("3. Manage schedule.");
                Console.WriteLine("4. Search.");
                Console.WriteLine("5. Close application.");

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:
                            close = true;
                            break;

                    }
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}
