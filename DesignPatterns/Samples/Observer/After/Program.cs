using System;

namespace Observer.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var subject = new AlarmSystem();

            var guard1 = new SecurityGuard("guard1", subject);
            var guard2 = new SecurityGuard("guard2", subject);
            var guard3 = new SecurityGuard("guard3", subject);

            subject.Start();

            Console.ReadLine();
        }
    }
}