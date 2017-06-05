using System;

namespace DI.After
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
            Console.WriteLine("Financier Collecting Taxes");
            _secretary.WriteEveryThingDown();
        }
    }
}