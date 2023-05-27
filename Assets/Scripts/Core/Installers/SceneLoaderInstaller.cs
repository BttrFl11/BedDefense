using Core.SceneManagement;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader _sceneLoader;

        public override void InstallBindings()
        {
            SceneLoader instance = Container.InstantiatePrefabForComponent<SceneLoader>(_sceneLoader);
            Container.Bind<SceneLoader>().FromInstance(instance);
        }
    }
}