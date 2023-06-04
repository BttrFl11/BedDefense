using ScriptableObjects.Data;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    [CreateAssetMenu(menuName = GameConst.SCRIPTABLE_OBJECTS_PATH + "Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameSettings _settings;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings).IfNotBound();
        }
    }
}