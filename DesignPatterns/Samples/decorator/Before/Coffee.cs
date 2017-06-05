using System;

namespace Decorator.Before
{
    public class Coffee : IBeverage
    {
        public virtual void Prepare()
        {
            Console.Write("Preparing Coffee");
        }
    }
}