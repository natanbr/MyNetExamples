using System;

namespace DI.Middle
{
    public class Prince : IKing
    {
        private readonly IFinancier _financier;

        public Prince(IFinancier financier)
        {
            _financier = financier;
        }

        public void RuleTheCastle()
        {
            Console.WriteLine("Prince");
            _financier.CollectTaxes();
        }
    }
}