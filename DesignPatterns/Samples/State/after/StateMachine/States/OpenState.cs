namespace StatePattern
{
    public class OpenState : State
    {
        public OpenState(IDocument document, IStateMachine stateMachine) :
            base(document, stateMachine)
        {
        }

        public override bool Open()
        {
            return false;
        }

        public override bool Close()
        {
            if (! _document.Close())
                return false;

            _stateMachine.MoveToClosed();

            return true;
        }

        public override bool Save()
        {
            return false;
        }
    }
}