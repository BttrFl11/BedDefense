using UnityEngine;
using Zenject;

namespace Core.State.States
{
    public class DayState : IDayState
    {
        private readonly DayStateController _controller;

        public DayStateController Controller => _controller;

        public DayState(DayStateController controller)
        {
            _controller = controller;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
