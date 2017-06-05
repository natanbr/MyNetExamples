using System;

namespace DI.After
{
    internal class ModernSecretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Type everything into the computer");
        }
    }
}