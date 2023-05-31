using Core.Gameplay.EnemySpawn;
using System;
using UnityEngine;
using Zenject;

namespace Core.State.States
{
    public class DayState_Night : DayState
    {
        public override void Enter()
        {
            base.Enter();

            Debug.Log("Night");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Night Exit");
        }
    }
}
