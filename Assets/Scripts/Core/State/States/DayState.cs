using System;

namespace Core.State.States
{
    public class DayState : AttributedState
    {
        private readonly DayStateController _controller;

        public DayStateController Controller => _controller;

        public event Action OnEnter;
        public event Action OnExit;

        public DayState(DayStateController controller)
        {
            _controller = controller;
        }

        public override void _Enter()
        {
            base._Enter();

            OnEnter?.Invoke();
        }

        public override void _Exit()
        {
            base._Exit();

            OnExit?.Invoke();
        }
    }
}
