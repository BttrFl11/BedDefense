using Core.Gameplay.Unit.Enemy.Systems;
using ScriptableObjects.SO;
using Zenject;

namespace Core.Gameplay.Unit.Enemy
{
    public class EnemyIdentity : UnitIdentity
    {
        private EnemyRegistry _registry;

        [Inject]
        private void Construct(EnemyRegistry registry)
        {
            _registry = registry;
        }

        private void OnEnable()
        {
            _registry.Add(this);
        }

        private void OnDisable()
        {
            _registry.Remove(this);
        }
    }
}