using System;

namespace Decorator.Before
{
    public class Tea : IBeverage
    {
        public virtual void Prepare()
        {
            Console.Write("Preparing Tea");
        }
    }
}