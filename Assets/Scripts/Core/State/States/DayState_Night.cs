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
            Debug.Log("Night");
        }

        private void End()
        {
            Controller.Change<DayState_Morning>();
        }

        public override void Exit()
        {
            Debug.Log("Night Exit");
        }
    }
}
