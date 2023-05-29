using UnityEngine;

namespace Core.State.States
{
    public class DayState_Morning : DayState
    {
        public DayState_Morning(DayStateController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            Debug.Log("Morning");
        }

        private void End()
        {
            Controller.Change<DayState_Night>();
        }

        public override void Exit()
        {
            Debug.Log("Morning Exit");
        }
    }
}
