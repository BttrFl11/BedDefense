using ScriptableObjects.SO;

namespace Core.Gameplay.Unit.Character
{
    public class CharacterIdentity : UnitIdentity
    {
        public CharacterDataSO GetData()
        {
            return (CharacterDataSO)_data;
        }
    }
}