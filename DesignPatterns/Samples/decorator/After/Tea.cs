using System;

namespace Decorator.After
{
    public class Tea : IBeverage
    {
        public void Prepare()
        {
            Console.Write("Preparing Tea");
        }
    }
}