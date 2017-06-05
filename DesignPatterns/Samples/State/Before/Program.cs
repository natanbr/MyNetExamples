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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Test()
        {
            var app = new Application();

            CheckState(app, "Closed");

            bool ok = app.Open();

            CheckState(app, "Open");

            ok = app.Close();

            CheckState(app, "Closed");
        }

        private static void CheckState(Application app, string stateName)
        {
            Console.WriteLine("StatePattern is " + app.CurrentState);
            if (!app.CurrentState.ToString().Contains(stateName))
                throw new Exception("Unexpected state");
        }
    }
}