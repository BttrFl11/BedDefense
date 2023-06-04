using ScriptableObjects.Data.Unit;
using ScriptableObjects.Data.Unit.Building;
using UnityEngine;

namespace ScriptableObjects.SO
{
    public class BuildingDataSO : ScriptableObject
    {
        [SerializeField] private BuildingHealthData _healthData;

        public BuildingHealthData HealthData => _healthData;
    }

}