using Core.Gameplay.Interfaces;
using Core.State.Attributes;

namespace Core.Gameplay.Unit.Enemy.Systems.State
{
    public class EnemyState_Move : EnemyState
    {
        private IEnemyTarget _endTarget;

        public EnemyState_Move(EnemyStateController controller, IEnemyTarget endTarget) 
            : base(controller)
        {
            _endTarget = endTarget;
        }

        [Frame]
        private void Update()
        {

        }
    }
}
