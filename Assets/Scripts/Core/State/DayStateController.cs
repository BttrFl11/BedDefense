using Core.State.States;
using System.Collections.Generic;
using Zenject;

namespace Core.State
{
    public class DayStateController : StateController<DayState>
    {
        [Inject]
        private void Construct(DayState_Morning morning, DayState_Night night)
        {
            _states = new List<DayState>
            {
                morning, night
            };

            CurrentState = _states[0];
        }
    }
}