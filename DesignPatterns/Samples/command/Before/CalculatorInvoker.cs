using System;
using System.Collections.Generic;

namespace Command.Before
{
    public class CalculatorInvoker
    {
        private readonly Calculator _calculator;
        private readonly Stack<Arguments> _stack;

        public CalculatorInvoker(Calculator calculator)
        {
            _calculator = calculator;
            _stack = new Stack<Arguments>();
        }

        public decimal Do(char operation, decimal operand)
        {
            var arguments = new Arguments
            {
                Operand = operand,
                Operation = operation
            };

            _stack.Push(arguments);
            return _calculator.Operation(arguments.Operation, arguments.Operand);
        }

        public decimal UnDo()
        {
            if (_stack.Count > 0)
            {
                Arguments args = _stack.Pop();
                return _calculator.Inverse(args.Operation, args.Operand);
            }
            throw new Exception();
        }
    }
}