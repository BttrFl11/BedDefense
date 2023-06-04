using Core.State.Attributes;
using UnityEngine;

namespace Core.State.States
{
    public class DayState_Morning : DayState
    {
        public DayState_Morning(DayStateController controller) : base(controller)
        {
        }

        [Enter]
        private void Enter()
        {
            Debug.Log("Morning");
        }

        [Wait(3f)]
        private void End()
        {
            Controller.Change<DayState_Night>();
        }

        [Exit]
        private void Exit()
        {
            Debug.Log("Morning Exit");
        }
    }
}
