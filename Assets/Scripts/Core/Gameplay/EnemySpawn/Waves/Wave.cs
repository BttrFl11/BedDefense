using Core.Gameplay.Enemy;
using System;

namespace Core.Gameplay.EnemySpawn.Waves
{
    [Serializable]
    public struct Wave
    {
        public EnemyIdentity[] EnemyPrefabs;
        public int EnemeisCount;
    }
}
