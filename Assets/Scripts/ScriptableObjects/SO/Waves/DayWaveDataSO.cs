using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "EnemySpawn/Day Wave")]
    public class DayWaveDataSO : ScriptableObject
    {
        [SerializeField] private Vector2Int _minMaxWavesCount;

        public Vector2Int MinMaxWavesCount => _minMaxWavesCount;
    }
}