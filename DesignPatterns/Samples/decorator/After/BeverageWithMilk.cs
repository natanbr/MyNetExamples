using System;

namespace Decorator.After
{
    internal class BeverageWithMilk : IBeverage
    {
        private readonly IBeverage _beverage;

        public BeverageWithMilk(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public void Prepare()
        {
            _beverage.Prepare();
            Console.Write(" + milk");
        }
    }
}