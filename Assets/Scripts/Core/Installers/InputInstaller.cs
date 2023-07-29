using Core.Input;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [Inject] private DeviceInfo _deviceInfo;

        public override void InstallBindings()
        {
            CreateService();

            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
        }

        private void CreateService()
        {
            if (_deviceInfo.IsMobile)
            {
                //Container.Bind<IInputService>().To<InputService_Mobile>().AsSingle();
            }
            else
            {
                Debug.Log("1");

                Container.Bind<IInputService>().To<InputService_PC>().AsSingle();
            }
        }
    }
}