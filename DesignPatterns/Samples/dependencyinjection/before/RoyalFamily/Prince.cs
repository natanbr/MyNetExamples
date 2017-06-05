using System;

namespace DI.Before
{
    public class Prince
    {
        private readonly IFinancier _financier;

        public Prince()
        {
            _financier = new Financier();
        }

        public void RuleTheCastle()
        {
            Console.WriteLine("Prince");
            _financier.CollectTaxes();
        }
    }
}