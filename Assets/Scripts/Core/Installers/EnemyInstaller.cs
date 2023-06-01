using Core.Gameplay.Enemy.Systems;
using Core.Gameplay.EnemySpawn;
using ScriptableObjects.SO;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawnerSO _enemySpawnerData;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(_enemySpawnerData);
            Container.Bind<EnemySpawner.Spawner>().AsSingle();
            Container.Bind<EnemyRegistry>().AsSingle();
        }
    }
}