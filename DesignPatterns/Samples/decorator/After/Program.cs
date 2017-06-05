using System;
using System.Collections.Generic;

namespace Decorator.After
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var beverages = new List<IBeverage>
            {
                new Coffee(),
                new Tea(),
                new BeverageWithMilk(new Coffee()),
                new BeverageWithSugar(
                    new BeverageWithMilk(
                        new Tea())),
            };

            var t = new BeverageWithSugar(
                      new BeverageWithMilk(
                        new Tea()));

            foreach (IBeverage beverage in beverages)
            {
                beverage.Prepare();
                Console.WriteLine();
            }
        }
    }
}