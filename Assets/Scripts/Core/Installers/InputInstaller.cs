using Core.Input;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        private InputProvider _inputProvider;

        public override void InstallBindings()
        {
            _inputProvider = new InputProvider();
            Container.Bind<InputProvider>().FromInstance(_inputProvider).AsSingle();

#if UNITY_EDITOR || UNITY_STANDALONE
            _inputProvider.CreatePCInputService();
#else
            _inputProvider.CreateMobileInputService();
#endif

            Container.Bind<IInputService>().FromInstance(_inputProvider.InputService).AsSingle();
        }

        private void OnDisable()
        {
            _inputProvider.OnDisable();
        }

        private void Update()
        {
            _inputProvider.Update();
        }
    }
}