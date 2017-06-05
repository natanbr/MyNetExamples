﻿using System;
using System.Timers;

namespace DelegatesAndEvents
{
    class DryContactDetector
    {
        public event Action<string> OnDetected;

        private readonly System.Timers.Timer _timer;

        public DryContactDetector()
        {
            _timer = new Timer(200);
            _timer.Elapsed += timer_Elapsed;   
        }

        public void Run()
        {
            _timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (OnDetected != null)
            {
                OnDetected("BreakIn!");
            }
        }
    }
}