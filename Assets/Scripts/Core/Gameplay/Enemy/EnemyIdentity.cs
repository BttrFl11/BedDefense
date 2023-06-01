using Core.Gameplay.Enemy.Systems;
using Core.Gameplay.Unit;
using ScriptableObjects.SO;
using Zenject;

namespace Core.Gameplay.Enemy
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

        public EnemyDataSO GetData()
        {
            return (EnemyDataSO)_data;
        }
    }
}