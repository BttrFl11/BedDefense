using ScriptableObjects.Data;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Unit.Character.Systems
{
    [DisallowMultipleComponent]
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [Inject]
        private void Construct(CharacterIdentity character)
        {
            character.transform.position = transform.position;
        }
    }
}
