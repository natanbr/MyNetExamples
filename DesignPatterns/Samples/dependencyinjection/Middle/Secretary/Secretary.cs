using System;

namespace DI.Middle
{
    internal class Secretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Writing everything on paper");
        }
    }
}