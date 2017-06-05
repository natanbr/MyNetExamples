using System;

namespace DI.Before
{
    class Secretary : ISecretary
    {
        public void WriteEveryThingDown()
        {
            Console.WriteLine("Writing everything on paper");
        }
    }
}