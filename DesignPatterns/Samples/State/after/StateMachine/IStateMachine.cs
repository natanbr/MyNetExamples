namespace StatePattern
{
    public interface IStateMachine
    {
        void MoveToOpen();
        void MoveToClosed();
    }
}