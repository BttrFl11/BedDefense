using UnityEngine;

namespace ScriptableObjects.SO
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Enemy Spawner")]
    public class EnemySpawnerSO : ScriptableObject
    {
        [SerializeField] private int _dayWavesCount;
        [SerializeField] private bool _similarDaysAvailable;
        [SerializeField] private bool _similarWavesAvailable;
        [SerializeField] private bool _similarWavesInDayAvailable;

        public int DayWavesCount => _dayWavesCount;
        public bool SimilarDaysAvailable => _similarDaysAvailable;
        public bool SimilarWavesAvailable => _similarWavesAvailable;
        public bool SimilarWavesInDayAvailable => _similarWavesInDayAvailable;
    }
}