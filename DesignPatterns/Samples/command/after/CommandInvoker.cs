using System;
using System.Collections.Generic;

namespace Command.After
{
    public class CommandInvoker<T> : ICommandInvoker<T>
    {
        private readonly Stack<ICommand<T>> _commandStack;

        public CommandInvoker()
        {
            _commandStack = new Stack<ICommand<T>>();
        }

        public T Do(ICommand<T> command)
        {
            _commandStack.Push(command);
            return command.Do();
        }

        public T Undo()
        {
            if (_commandStack.Count > 0)
            {
                ICommand<T> command = _commandStack.Pop();
                return command.Undo();
            }
            throw new Exception();
        }
    }
}