using Core.Gameplay.Unit;
using ScriptableObjects;

namespace Core.Gameplay.Enemy
{
    public class EnemyIdentity : UnitIdentity
    {
        public EnemyDataSO GetData()
        {
            return (EnemyDataSO)_data;
        }
    }
}