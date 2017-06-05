using System;

namespace DI.Middle
{
    internal class ModernSecretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Type everything into the computer");
        }
    }
}