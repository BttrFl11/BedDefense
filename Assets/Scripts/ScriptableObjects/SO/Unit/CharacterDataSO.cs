using ScriptableObjects.Data.Unit.Character;
using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Character Data")]
    public class CharacterDataSO : UnitDataSO
    {
        [SerializeField] private CharacterFightingData _fighting;
        [SerializeField] private CharacterHealthData _health;
        [SerializeField] private CharacterMovementData _movement;

        public CharacterFightingData Fighting => _fighting;
        public CharacterHealthData Health => _health;
        public CharacterMovementData Movement => _movement;
    }
}