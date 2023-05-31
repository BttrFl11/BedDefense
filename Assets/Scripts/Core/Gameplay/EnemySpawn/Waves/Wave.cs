using Core.Gameplay.Enemy;
using System;
using UnityEngine;

namespace Core.Gameplay.EnemySpawn.Waves
{
    [Serializable]
    public struct Wave
    {
        public EnemyIdentity[] EnemyPrefabs;
        public int EnemeisCount;
        public Vector2 MinMaxSpawnTime;
    }
}
