using Core.Gameplay.Unit;
using ScriptableObjects;

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