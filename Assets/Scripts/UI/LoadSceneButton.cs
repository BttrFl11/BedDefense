using Core.SceneManagement;
using UnityEngine;
using Zenject;

namespace UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Load(int sceneId)
        {
            _sceneLoader.Load(sceneId);
        }

        public void LoadNext()
        {
            _sceneLoader.LoadNext();
        }
    }
}