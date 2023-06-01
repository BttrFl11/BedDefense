using Core.Input;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        private DeviceInfo _deviceInfo;

        [Inject]
        private void Construct(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();

            CreateService();
        }

        private void CreateService()
        {
            if (_deviceInfo.IsMobile)
            {
                //Container.Bind<IInputService>().To<InputService_Mobile>().AsSingle();
            }
            else
            {
                Container.Bind<IInputService>().To<InputService_PC>().AsSingle();
            }
        }
    }
}