using System;

namespace Observer.Before
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var guard = new SecurityGuard("guard");

            var subject = new AlarmSystem(guard);

            subject.Start();

            Console.ReadLine();
        }
    }
}