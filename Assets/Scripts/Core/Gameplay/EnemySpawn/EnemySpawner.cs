using Core.Gameplay.EnemySpawn.Waves;
using ScriptableObjects.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Core.Gameplay.EnemySpawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerSO _data;

        [SerializeField] private DayWave[] _dayWaves;

        private void Awake()
        {
            _dayWaves = new DayWave[_data.DayWavesCount];
            List<DayWaveDataSO> allDaysData = new();
            allDaysData.AddRange(Resources.LoadAll<DayWaveDataSO>(GameConst.DAY_WAVE_DATA_PATH));
            List<WaveDataSO> allWavesData = new();
            allWavesData.AddRange(Resources.LoadAll<WaveDataSO>(GameConst.WAVE_DATA_PATH));
            List<WaveDataSO> allWavesDataInDay = new(allWavesData);

            print(allWavesData.Count);
            print(allDaysData.Count);

            for (int i = 0; i < _dayWaves.Length; i++)
            {
                DayWaveDataSO dayData = Randomizer.GetElement<DayWaveDataSO>(allDaysData.ToArray());
                int wavesCount = Randomizer.GetValueFromVector(dayData.MinMaxWavesCount);
                _dayWaves[i].Waves = new Wave[wavesCount];

                if (_data.SimilarDaysAvailable == false)
                    allDaysData.Remove(dayData);

                for (int j = 0; j < _dayWaves[i].Waves.Length; j++)
                {
                    WaveDataSO waveData = Randomizer.GetElement<WaveDataSO>(allWavesDataInDay.ToArray());
                    int enemiesCount = Randomizer.GetValueFromVector(waveData.MinMaxEnemiesCount);

                    _dayWaves[i].Waves[j].EnemeisCount = enemiesCount;
                    _dayWaves[i].Waves[j].EnemyPrefabs = waveData.EnemyPrefabs;

                    if (_data.SimilarWavesInDayAvailable == false)
                        allWavesDataInDay.Remove(waveData);

                    if (_data.SimilarWavesAvailable == false)
                    {
                        allWavesData.Remove(waveData);

                        if (_data.SimilarWavesInDayAvailable == false)
                            allWavesDataInDay = new(allWavesData);
                    }
                }
            }
        }

        private void Start()
        {

        }

        private IEnumerator StartSpawn()
        {


            yield return null;
        }
    }
}