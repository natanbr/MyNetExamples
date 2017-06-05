namespace Command.After
{
    public class Calculator
    {
        private decimal _curr;

        public decimal Operation(char operation, decimal operand)
        {
            switch (operation)
            {
                case '+':
                    _curr += operand;
                    break;
                case '-':
                    _curr -= operand;
                    break;
                case '*':
                    _curr *= operand;
                    break;
                case '/':
                    _curr /= operand;
                    break;
            }

            return _curr;
        }

        public decimal Inverse(char operation, decimal operand)
        {
            return Operation(Inverse(operation), operand);
        }

        private char Inverse(char operation)
        {
            switch (operation)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    return ' ';
            }
        }
    }
}