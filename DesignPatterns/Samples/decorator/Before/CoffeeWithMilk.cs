using System;

namespace Decorator.Before
{
    internal class CoffeeWithMilk : Coffee
    {
        public override void Prepare()
        {
            base.Prepare();
            Console.Write(" + milk");
        }
    }
}