using System;

namespace Decorator.After
{
    internal class BeverageWithSugar : IBeverage
    {
        private readonly IBeverage _beverage;

        public BeverageWithSugar(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public void Prepare()
        {
            _beverage.Prepare();
            Console.Write(" + sugar");
        }
    }
}