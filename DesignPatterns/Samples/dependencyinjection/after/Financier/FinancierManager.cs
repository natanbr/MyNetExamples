using System;

namespace DI.After
{
    public class FinancierManager : IFinancier
    {
        private readonly ISecretary _secretary;

        public FinancierManager(ISecretary secretary)
        {
            _secretary = secretary;
        }

        public void CollectTaxes()
        {
            Console.WriteLine("Financier Manager Collecting Taxes");
            _secretary.WriteEveryThingDown();
        }
    }
}