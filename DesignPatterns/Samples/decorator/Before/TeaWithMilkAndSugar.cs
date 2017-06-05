using System;

namespace Decorator.Before
{
    internal class TeaWithMilkAndSugar : Tea
    {
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine(" + milk + sugar");
        }
    }
}