using System.Collections.Generic;

namespace Core.Gameplay.Unit.Enemy.Systems
{
    public class EnemyRegistry
    {
        private List<EnemyIdentity> _enemies = new List<EnemyIdentity>();

        public IEnumerable<EnemyIdentity> Enemies => _enemies;
        public int Count => _enemies.Count;

        public void Add(EnemyIdentity identity)
        {
            _enemies.Add(identity);
        }

        public void Remove(EnemyIdentity identity)
        {
            _enemies.Remove(identity);
        }
    }
}
