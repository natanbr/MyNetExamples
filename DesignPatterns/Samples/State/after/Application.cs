namespace StatePattern
{
    public class Application
    {
        private readonly StateMachine _stateMachine;

        public Application()
        {
            var document = new Document();
            _stateMachine = new StateMachine(document);
        }

        public State CurrentState
        {
            get { return _stateMachine.CurrentState; }
        }

        public bool Open()
        {
            return _stateMachine.Open();
        }

        public void Close()
        {
            _stateMachine.Close();
        }

        public bool Save()
        {
            return _stateMachine.Save();
        }
    }
}