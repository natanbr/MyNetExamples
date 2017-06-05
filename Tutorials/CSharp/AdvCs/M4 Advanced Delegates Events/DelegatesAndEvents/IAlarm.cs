using System;

namespace DelegatesAndEvents
{
    interface IAlarm
    {
        event Action<string> OnBreakIn;
        event Action<string> OnFire;
    }
}