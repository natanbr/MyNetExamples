using System;
using System.Collections.Generic;

namespace Decorator.Before
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var beverages = new List<IBeverage>
            {
                new Coffee(),
                new Tea(),
                new CoffeeWithMilk(),
                new TeaWithMilkAndSugar()
            };

            foreach (IBeverage beverage in beverages)
            {
                beverage.Prepare();
                Console.WriteLine();
            }
        }
    }
}