using UnityEngine;

namespace Core.SceneManagement
{
    public abstract class SceneLoader : MonoBehaviour
    {
        public abstract void Load(int sceneId);
        public abstract void LoadNext();
    }
}