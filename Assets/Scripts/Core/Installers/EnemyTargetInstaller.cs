using Core.Gameplay.Interfaces;
using Zenject;

namespace Core.Installers
{
    public class EnemyTargetInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyTarget>().FromComponentInHierarchy(false).AsSingle();
        }
    }
}