using Core.State.Attributes;
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
            base.Enter();

            Debug.Log("Morning");
        }

        [Wait(2f)]
        private void End()
        {
            Controller.Change<DayState_Night>();
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Morning Exit");
        }
    }
}
