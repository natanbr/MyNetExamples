namespace Command.After
{
    public class CalculatorCommand : ICommand<decimal>
    {
        private readonly Arguments _arguments;
        private readonly Calculator _receiver;

        public CalculatorCommand(Calculator receiver, char operation, decimal operand)
        {
            _arguments = new Arguments
            {
                Operation = operation,
                Operand = operand
            };
            _receiver = receiver;
        }

        public decimal Do()
        {
            return _receiver.Operation(_arguments.Operation, _arguments.Operand);
        }

        public decimal Undo()
        {
            return _receiver.Inverse(_arguments.Operation, _arguments.Operand);
        }
    }
}