using ScriptableObjects.Data.Unit.Enemy;
using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Enemy Data")]
    public class EnemyDataSO : UnitDataSO
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private EnemyPlaceholderData _placeholder;
        [SerializeField] private EnemyFightingData _fighting;
        [SerializeField] private EnemyHealthData _health;
        [SerializeField] private EnemyMovementData _movement;

        public EnemyFightingData Fighting => _fighting;
        public EnemyHealthData Health => _health;
        public EnemyMovementData Movement => _movement;
        public EnemyPlaceholderData Placeholder => _placeholder;
        public float RotationSpeed => _rotationSpeed;
    }
}