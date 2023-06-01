using ScriptableObjects.Data.Unit.Character;
using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Character Data")]
    public class CharacterDataSO : UnitDataSO
    {
        [SerializeField] private CharacterFightingData _fightingData;
        [SerializeField] private CharacterHealthData _healthData;
        [SerializeField] private CharacterMovementData _movementData;

        public CharacterFightingData FightingData => _fightingData;
        public CharacterHealthData HealthData => _healthData;
        public CharacterMovementData MovementData => _movementData;
    }
}