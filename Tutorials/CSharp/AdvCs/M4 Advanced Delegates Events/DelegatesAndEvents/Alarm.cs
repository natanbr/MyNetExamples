using System;

namespace DelegatesAndEvents
{
    internal class Alarm : IAlarm
    {
        private readonly DryContactDetector _dryContactDetector;
        private readonly SmokeDetector _smokeDetector;

        public Alarm()
        {
            _smokeDetector = new SmokeDetector();
            _dryContactDetector = new DryContactDetector();
            _dryContactDetector.OnDetected += _dryContactDetector_OnDetected;
        }

        // Use delegate implementation

        public event Action<string> OnBreakIn;

        // Implement event by passing on registration to the smoke detector
        
        public event Action<string> OnFire
        {
            add { _smokeDetector.OnDetected += value; }
            remove { _smokeDetector.OnDetected -= value; }
        }

        private void _dryContactDetector_OnDetected(string obj)
        {
            if (OnBreakIn != null)
            {
                OnBreakIn(obj);
            }
        }

        public void Run()
        {
            _smokeDetector.Run();
            _dryContactDetector.Run();
        }
    }
}