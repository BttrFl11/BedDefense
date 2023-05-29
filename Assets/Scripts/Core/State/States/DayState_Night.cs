using Core.State.Attributes;
using UnityEngine;

namespace Core.State.States
{
    public class DayState_Night : DayState
    {
        public DayState_Night(DayStateController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Night");
        }

        [Wait(2f)]
        private void End()
        {
            Controller.Change<DayState_Morning>();
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Night Exit");
        }
    }
}
