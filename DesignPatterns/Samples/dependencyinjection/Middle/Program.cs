namespace DI.Middle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoWork();
        }

        private static void DoWork()
        {
            var secretary = new ModernSecretary();
            var financier = new Financier(secretary);
            var king = new King(financier);

            king.RuleTheCastle();
        }
    }
}