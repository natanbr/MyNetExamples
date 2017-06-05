using System;

namespace DI.Before
{
    public class King
    {
        private readonly Financier _financier;

        public King()
        {
            _financier = new Financier();
        }

        public void RuleTheCastle()
        {
            Console.WriteLine("King");
            _financier.CollectTaxes();
        }
    }
}