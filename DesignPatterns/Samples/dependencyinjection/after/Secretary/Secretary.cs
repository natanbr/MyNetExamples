using System;

namespace DI.After
{
    internal class Secretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Writing everything on paper");
        }
    }
}