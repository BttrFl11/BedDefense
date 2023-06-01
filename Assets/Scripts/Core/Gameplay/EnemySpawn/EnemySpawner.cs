using Core.Gameplay.Unit.Enemy;
using Core.Gameplay.Unit.Enemy.Systems;
using Core.Gameplay.EnemySpawn.Waves;
using Core.State;
using Core.State.States;
using ScriptableObjects.SO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utils;
using Zenject;

namespace Core.Gameplay.EnemySpawn
{
    public class EnemySpawner : ITickable, IDisposable
    {
        private EnemySpawnerSO _data;

        private DayWave[] _days;
        private DayWave _day;
        private Spawner _spawner;
        private bool _spawn;
        private int _dayIndex;
        private DayStateController _stateController;

        public event Action OnAllEnemiesDied;

        public EnemySpawner(DayStateController stateController, EnemySpawnerSO data, Spawner spawner)
        {
            _stateController = stateController;
            _spawner = spawner;
            _data = data;

            Init();

            _stateController.Find<DayState_Night>().OnEnter += OnNightStart;
            OnAllEnemiesDied += Stop;
        }

        public void Dispose()
        {
            _stateController.Find<DayState_Night>().OnEnter -= OnNightStart;
            OnAllEnemiesDied -= Stop;
        }

        private void Init()
        {
            _days = new DayWave[_data.DayWavesCount];
            List<DayWaveDataSO> allDaysData = new();
            allDaysData.AddRange(Resources.LoadAll<DayWaveDataSO>(GameConst.DAY_WAVE_DATA_PATH));
            List<WaveDataSO> allWavesData = new();
            allWavesData.AddRange(Resources.LoadAll<WaveDataSO>(GameConst.WAVE_DATA_PATH));
            List<WaveDataSO> allWavesDataInDay = new(allWavesData);

            for (int i = 0; i < _days.Length; i++)
            {
                DayWaveDataSO dayData = Randomizer.GetElement<DayWaveDataSO>(allDaysData.ToArray());
                int wavesCount = Randomizer.GetValueFromVector(dayData.MinMaxWavesCount);
                _days[i].Waves = new Wave[wavesCount];

                if (_data.SimilarDaysAvailable == false)
                    allDaysData.Remove(dayData);

                for (int j = 0; j < _days[i].Waves.Length; j++)
                {
                    WaveDataSO waveData = Randomizer.GetElement<WaveDataSO>(allWavesDataInDay.ToArray());

                    ParseWave(waveData, i, j);

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

            void ParseWave(WaveDataSO data, int dayIndex, int waveIndex)
            {
                int enemiesCount = Randomizer.GetValueFromVector(data.MinMaxEnemiesCount);

                _days[dayIndex].Waves[waveIndex].EnemeisCount = enemiesCount;
                _days[dayIndex].Waves[waveIndex].EnemyPrefabs = data.EnemyPrefabs;
                _days[dayIndex].Waves[waveIndex].MinMaxSpawnTime = data.MinMaxSpawnTime;

            }

            _dayIndex = 0;
        }

        private void OnNightStart()
        {
            _spawn = true;
            _day = _days[_dayIndex];
            _dayIndex++;

            _spawner.Init(_day, OnAllEnemiesDied);
        }

        private void Stop()
        {
            _spawn = false;

            _stateController.Change<DayState_Morning>();
        }

        public void Tick()
        {
            if (_spawn == false) return;

            if (_spawner != null)
                _spawner.Tick(Time.deltaTime);
        }

        public class Spawner
        {
            private DayWave _dayWave;
            private Action _onAllEnemiesDie;
            private Wave _wave;
            private int _waveIndex;
            private int _amountToSpawn;
            private float _spawnTime;
            private bool _stop = false;
            private DiContainer _diContainer;
            private EnemyRegistry _registry;

            private int AmountToSpawn
            {
                get => _amountToSpawn;
                set
                {
                    _amountToSpawn = value;
                    if (_amountToSpawn <= 0)
                        UpdateWave();
                }
            }

            public Spawner(DiContainer diContainer, EnemyRegistry registry)
            {
                _diContainer = diContainer;
                _registry = registry;
            }

            public void Init(DayWave dayWave, Action onAllEnemiesDie)
            {
                _dayWave = dayWave;
                _onAllEnemiesDie = onAllEnemiesDie;

                _stop = false;
                _waveIndex = 0;

                UpdateWave();
            }

            private async void WaitToAllEnemiesDie()
            {
                while(_registry.Count > 0)
                {
                    await Task.Delay(100);
                }

                _onAllEnemiesDie?.Invoke();
            }

            private void UpdateWave()
            {
                if (_waveIndex >= _dayWave.Waves.Length)
                {
                    WaitToAllEnemiesDie();
                    _stop = true;
                    return;
                }

                _wave = _dayWave.Waves[_waveIndex];

                _spawnTime = Randomizer.GetValueFromVector(_wave.MinMaxSpawnTime);
                AmountToSpawn = _wave.EnemeisCount;

                _waveIndex++;
            }

            public void Tick(float deltaTime)
            {
                if (_stop) return;

                _spawnTime -= deltaTime;

                if (_spawnTime <= 0)
                {
                    SpawnEnemy();
                }
            }

            private void SpawnEnemy()
            {
                EnemyIdentity prefab = GetRandomPrefab();
                _diContainer.InstantiatePrefabForComponent<EnemyIdentity>(prefab);

                _spawnTime = Randomizer.GetValueFromVector(_wave.MinMaxSpawnTime);
                AmountToSpawn--;
            }

            private EnemyIdentity GetRandomPrefab()
            {
                return Randomizer.GetElement<EnemyIdentity>(_wave.EnemyPrefabs);
            }
        }
    }
}