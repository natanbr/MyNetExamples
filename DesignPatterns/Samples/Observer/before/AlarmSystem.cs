using System;
using System.Threading;

namespace Observer.Before
{
    internal class AlarmSystem
    {
        private readonly SecurityGuard _guard;
        private readonly Thread _thread;

        public AlarmSystem(SecurityGuard guard)
        {
            _guard = guard;
            _thread = new Thread(Monitor) {IsBackground = true};
        }

        public void Start()
        {
            _thread.Start();
        }

        private void Monitor()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                TriggerAlarm(String.Format("Alarm at {0}", i*100));
            }
        }

        private void TriggerAlarm(string msg)
        {
            _guard.AlarmTriggered(this, msg);
        }
    }
}