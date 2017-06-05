namespace Observer.After
{
    internal interface IAlarmSystem
    {
        void Subscribe(ISecurityObserver observer);
        void Unsubscribe(ISecurityObserver observer);
    }
}