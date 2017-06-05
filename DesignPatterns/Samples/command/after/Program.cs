using System;

namespace Command.After
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            try
            {
                RunMayThrow();
                Console.WriteLine("Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RunMayThrow()
        {
            var calculator = new Calculator();
            var invoker = new CommandInvoker<decimal>();

            decimal result = invoker.Do(new CalculatorCommand(calculator, '+', 5));
            AssertEqual(result, 5);

            result = invoker.Do(new CalculatorCommand(calculator, '-', 3));
            AssertEqual(result, 2);

            result = invoker.Undo();
            AssertEqual(result, 5);

            result = invoker.Undo();
            AssertEqual(result, 0);
        }

        private static void AssertEqual(decimal lhs, decimal rhs)
        {
            if (lhs != rhs)
                throw new Exception("Failed");
        }
    }
}