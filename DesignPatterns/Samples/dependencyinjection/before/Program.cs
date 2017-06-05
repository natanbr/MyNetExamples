namespace DI.Before
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoWork();
        }

        private static void DoWork()
        {
            var king = new King();
            king.RuleTheCastle();
        }
    }
}