namespace Observer.After
{
    internal interface ISecurityObserver
    {
        void AlarmTriggered(IAlarmSystem sender, string message);
    }
}