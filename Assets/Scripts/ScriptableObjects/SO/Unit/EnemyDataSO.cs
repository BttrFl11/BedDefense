using ScriptableObjects.Data.Enemy;
using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Enemy Data")]
    public class EnemyDataSO : UnitDataSO
    {
        [SerializeField] private EnemyFightingData _fightingData;
        [SerializeField] private EnemyHealthData _healthData;
        [SerializeField] private EnemyMovementData _movementData;

        public EnemyFightingData FightingData => _fightingData;
        public EnemyHealthData HealthData => _healthData;
        public EnemyMovementData MovementData => _movementData;
    }
}