using Core.State;
using System.Collections.Generic;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Systems.State
{
    public class EnemyStateController : StateController<EnemyState>
    {
        private void Construct(
            EnemyState_Move move,
            EnemyState_Attack attack)
        {
            _states = new List<EnemyState>
            {
                move, attack
            };

            CurrentState = _states[0];
        }
    }
}