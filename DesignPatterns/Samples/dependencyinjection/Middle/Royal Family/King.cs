using System;

namespace DI.Middle
{
    public class King : IKing
    {
        private readonly IFinancier _financier;

        public King(IFinancier financier)
        {
            _financier = financier;
        }

        public void RuleTheCastle()
        {
            Console.WriteLine("King");
            _financier.CollectTaxes();
        }
    }
}