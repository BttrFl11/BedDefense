using Core.Input;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameObject obj = new GameObject("InputProvider");
            InputProvider inputProvider = obj.AddComponent<InputProvider>();

            DontDestroyOnLoad(inputProvider);

#if UNITY_EDITOR || UNITY_STANDALONE
            inputProvider.CreatePCInputService();
#else
            inputProvider.CreateMobileInputService();
#endif

            Container.Bind<IInputService>().FromInstance(inputProvider.InputService).AsSingle();
        }
    }
}