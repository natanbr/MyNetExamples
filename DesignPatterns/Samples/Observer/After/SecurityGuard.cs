using System;

namespace Observer.After
{
    internal class SecurityGuard : ISecurityObserver
    {
        private readonly string name;

        public SecurityGuard(string name, IAlarmSystem subject)
        {
            this.name = name;
            subject.Subscribe(this);
        }

        public void AlarmTriggered(IAlarmSystem sender, string message)
        {
            Console.WriteLine(name + ": " + message);
        }
    }
}