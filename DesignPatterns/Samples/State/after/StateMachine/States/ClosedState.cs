namespace StatePattern
{
    public class ClosedState : State
    {
        public ClosedState(IDocument document, IStateMachine stateMachine) :
            base(document, stateMachine)
        {
        }

        public override bool Open()
        {
            if (!_document.Open())
                return false;

            _stateMachine.MoveToOpen();
            return true;
        }

        public override bool Close()
        {
            return false;
        }

        public override bool Save()
        {
            return false;
        }
    }
}