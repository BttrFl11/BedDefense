using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DeviceInfo>().AsSingle();
        }
    }
}