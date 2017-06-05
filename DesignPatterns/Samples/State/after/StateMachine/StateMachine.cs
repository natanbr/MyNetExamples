namespace StatePattern
{
    public class StateMachine : IStateMachine
    {
        private readonly ClosedState _closedState;
        private readonly IDocument _document;
        private readonly OpenState _openState;
        private State _currentState;

        public StateMachine(IDocument document)
        {
            _document = document;
            _closedState = new ClosedState(document, this);
            _openState = new OpenState(document, this);

            _currentState = _closedState;
        }

        public State CurrentState
        {
            get { return _currentState; }
        }

        public void MoveToOpen()
        {
            _currentState = _openState;
        }

        public void MoveToClosed()
        {
            _currentState = _closedState;
        }

        public bool Open()
        {
            return _currentState.Open();
        }

        public void Close()
        {
            _currentState.Close();
        }

        public bool Save()
        {
            return _currentState.Save();
        }
    }
}