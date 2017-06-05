using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Jobs
{
    internal static class NativeJobMain
    {
        private static void Execute(string[] args)
        {
            using (var job = new Job())
            {
                for (var i = 0; i < 4; i++)
                {
                    var p = Process.Start("notepad");
                    Debug.Assert(p != null);
                    job.AddProcessToJob(p);
                }
                Console.WriteLine("Press <Enter> to kill all notepad instances...");
                Console.ReadLine();

                job.Kill();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }
    }
}