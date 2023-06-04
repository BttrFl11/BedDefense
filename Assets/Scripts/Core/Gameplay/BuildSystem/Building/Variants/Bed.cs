using Core.Gameplay.Interfaces;
using ScriptableObjects.SO.Building.Variants;
using UnityEngine;

namespace Core.Gameplay.BuildSystem.Building.Variants
{
    public class Bed : Building<BedDataSO>, IEnemyTarget
    {
        public Transform Transform => transform;
    }
}
