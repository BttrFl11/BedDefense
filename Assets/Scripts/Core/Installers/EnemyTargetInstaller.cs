using Core.Gameplay.Interfaces;
using UnityEngine;
using Utils.InterfaceReference;
using Zenject;

namespace Core.Installers
{
    public class EnemyTargetInstaller : MonoInstaller
    {
        [SerializeField, GameObjectOfType(typeof(IEnemyTarget))] private GameObject _enemyTarget;

        public override void InstallBindings()
        {
            IEnemyTarget enemyTarget = _enemyTarget.GetComponent<IEnemyTarget>();

            Container.Bind<IEnemyTarget>().FromInstance(enemyTarget).AsSingle();
        }
    }
}