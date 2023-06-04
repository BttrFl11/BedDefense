using Core.State.Attributes;
using UnityEngine;

namespace Core.State.States
{
    public class DayState_Night : DayState
    {
        public DayState_Night(DayStateController controller) : base(controller)
        {
        }

        [Enter]
        private void Enter()
        {
            Debug.Log("Night");
        }

        [Exit]
        private void Exit()
        {
            Debug.Log("Night Exit");
        }
    }
}
