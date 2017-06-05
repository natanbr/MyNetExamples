using System;

namespace Observer.Before
{
    internal class SecurityGuard
    {
        private readonly string _name;

        public SecurityGuard(string name)
        {
            _name = name;
        }

        public void AlarmTriggered(AlarmSystem sender, string message)
        {
            Console.WriteLine(_name + ": " + message);
        }
    }
}