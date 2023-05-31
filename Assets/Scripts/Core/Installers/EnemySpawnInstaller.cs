using Core.Gameplay.EnemySpawn;
using ScriptableObjects.SO;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EnemySpawnInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawnerSO _enemySpawnerData;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(_enemySpawnerData);
            //Container.BindExecutionOrder<EnemySpawner>(-20);
        }
    }
}