using System;

namespace DI.Before
{
    class ModernSecretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Type everything into the computer");
        }
    }
}