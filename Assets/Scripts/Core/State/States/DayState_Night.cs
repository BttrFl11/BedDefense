using Core.State.Attributes;
using UnityEngine;

namespace Core.State.States
{
    public class DayState_Night : DayState
    {
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
