using System;

namespace StatePattern
{
    public class Application
    {
        public enum State
        {
            Open,
            Closed
        }

        private State _state;

        public Application()
        {
            _state = State.Closed;
        }

        public State CurrentState
        {
            get { return _state; }
        }

        public bool Open()
        {
            switch (_state)
            {
                case State.Open:
                    return false;

                case State.Closed:
                    if (_OpenDocument())
                    {
                        _state = State.Open;
                    }
                    return true;
            }
            return false;
        }

        public bool Close()
        {
            switch (_state)
            {
                case State.Open:
                    _CloseDocument();
                    _state = State.Closed;
                    return true;

                case State.Closed:
                    return false;
            }
            return false;
        }

        private bool _OpenDocument()
        {
            Console.WriteLine("Opening document");
            return true;
        }

        private void _CloseDocument()
        {
            Console.WriteLine("Closing document");
        }
    }
}