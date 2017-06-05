using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer.After
{
    internal class AlarmSystem : IAlarmSystem
    {
        private readonly List<ISecurityObserver> _observers = new List<ISecurityObserver>();
        private readonly Thread _thread;

        public AlarmSystem()
        {
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
            foreach (ISecurityObserver observer in _observers)
            {
                observer.AlarmTriggered(this, msg);
            }
        }

        #region IAlarmSystem Members

        public void Subscribe(ISecurityObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(ISecurityObserver observer)
        {
            _observers.Remove(observer);
        }

        #endregion
    }
}