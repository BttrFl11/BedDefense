using Core.State.States;

namespace Core.Gameplay.Unit.Enemy.Systems.State
{
    public class EnemyState : AttributedState
    {
        private readonly EnemyStateController _controller;

        public EnemyStateController Controller => _controller;

        public EnemyState(EnemyStateController controller)
        {
            _controller = controller;
        }
    }
}
