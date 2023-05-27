using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.SceneManagement
{
    public class SceneLoader_Animated : SceneLoader
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        private IEnumerator StartLoading(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

            operation.allowSceneActivation = false;
            _loadingScreen.SetActive(true);

            while(operation.isDone == false)
            {
                _loadingScreen.SetProgressBarFillAmount(operation.progress);
                if (operation.progress >= 0.9f)
                    break;

                yield return null;
            }

            _loadingScreen.SetActive(false);

            operation.allowSceneActivation = true;
        }

        public override void Load(int sceneId)
        {
            StartCoroutine(StartLoading(sceneId));
        }

        public override void LoadNext()
        {
            StartCoroutine(StartLoading(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}