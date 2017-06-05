using System;
using StatePattern;

namespace StateSample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Test();
                Console.WriteLine("Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Failed");
            }
        }

        private static void Test()
        {
            var app = new Application();

            CheckState(app, "Closed");

            bool ok = app.Open();

            CheckState(app, "Open");

            app.Close();

            CheckState(app, "Closed");
        }

        private static void CheckState(Application app, string stateName)
        {
            Console.WriteLine("State is " + app.CurrentState);
            if (! app.CurrentState.ToString().Contains(stateName))
                throw new Exception("Unexpected state");
        }
    }
}