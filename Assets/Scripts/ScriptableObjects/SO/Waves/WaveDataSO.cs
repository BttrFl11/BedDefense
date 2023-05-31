using Core.Gameplay.Enemy;
using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "EnemySpawn/Wave")]
    public class WaveDataSO : ScriptableObject
    {
        [SerializeField] private EnemyIdentity[] _enemyPrefabs;
        [SerializeField] private Vector2Int _minMaxEnemiesCount;
        [SerializeField] private Vector2 _minMaxSpawnTime;

        public EnemyIdentity[] EnemyPrefabs => _enemyPrefabs;
        public Vector2Int MinMaxEnemiesCount => _minMaxEnemiesCount;
        public Vector2 MinMaxSpawnTime => _minMaxSpawnTime;
    }
}