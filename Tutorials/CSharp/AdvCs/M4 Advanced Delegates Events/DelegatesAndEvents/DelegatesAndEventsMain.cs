using System;

namespace DelegatesAndEvents
{
    internal class DelegatesAndEventsMain
    {
        public static void Execute(string[] args)
        {
            var alarm = new Alarm();
            
            alarm.OnBreakIn += alarm_OnBreakIn;
            alarm.OnFire += alarm_OnFire;

            alarm.Run();

            Console.ReadLine();
        }

        private static void alarm_OnFire(string obj)
        {
            Console.WriteLine(obj);
        }

        private static void alarm_OnBreakIn(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}