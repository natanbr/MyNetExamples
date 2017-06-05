using System;

namespace DI.Middle
{
    public class Financier : IFinancier
    {
        private readonly ISecretary _secretary;

        public Financier(ISecretary secretary)
        {
            _secretary = secretary;
        }

        public void CollectTaxes()
        {
            Console.WriteLine("Collecting Taxes");
            _secretary.WriteEveryThingDown();
        }
    }
}