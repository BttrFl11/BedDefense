using Core.Gameplay.Unit;
using ScriptableObjects.SO;

namespace Core.Gameplay.Character
{
    public class CharacterIdentity : UnitIdentity 
    {
        public CharacterDataSO GetData()
        {
            return (CharacterDataSO)_data;
        }
    }
}