using System;

namespace Decorator.After
{
    public class Coffee : IBeverage
    {
        public void Prepare()
        {
            Console.Write("Preparing Coffee");
        }
    }
}