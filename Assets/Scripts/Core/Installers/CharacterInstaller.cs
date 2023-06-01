using Core.Gameplay.Unit.Character;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterIdentity _characterPrefab;

        public override void InstallBindings()
        {
            CharacterIdentity instance = Container.InstantiatePrefabForComponent<CharacterIdentity>(_characterPrefab);
            Container.Bind<CharacterIdentity>().FromInstance(instance);
        }
    }
}