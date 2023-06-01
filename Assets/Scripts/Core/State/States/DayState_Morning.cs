using Core.State.Attributes;
using UnityEngine;

namespace Core.State.States
{
    public class DayState_Morning : DayState
    {
        [Enter]
        private void Enter()
        {
            Debug.Log("Morning");
        }

        [Wait(3f)]
        private void End()
        {
            Debug.Log("M end");

            Controller.Change<DayState_Night>();
        }

        [Exit]
        private void Exit()
        {
            Debug.Log("Morning Exit");
        }
    }
}
