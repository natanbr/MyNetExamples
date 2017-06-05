using System;
using System.Threading;

namespace GarbageCollectionSamples
{
    public static class GarbageCollectionMain
    {
        public static void Execute()
        {
            // In Debug, the timer will run until the user hits enter
            // In Release t is disposed and the timer is called once

            var t = new Timer(TimerCallback, null, 0, 2000);

            Console.ReadLine();

            t.Dispose();
        }

        private static void TimerCallback(object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}

