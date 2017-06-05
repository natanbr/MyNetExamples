namespace Command.After
{
    public interface ICommand<T>
    {
        T Do();
        T Undo();
    }
}