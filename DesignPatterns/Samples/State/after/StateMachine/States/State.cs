namespace StatePattern
{
    public abstract class State
    {
        protected readonly IDocument _document;
        protected readonly IStateMachine _stateMachine;

        protected State(IDocument document, IStateMachine stateMachine)
        {
            _document = document;
            _stateMachine = stateMachine;
        }

        public abstract bool Open();
        public abstract bool Close();
        public abstract bool Save();
    }
}