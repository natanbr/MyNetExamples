namespace Command.After
{
    public interface ICommandInvoker<T>
    {
        T Do(ICommand<T> command);
        T Undo();
    }
}