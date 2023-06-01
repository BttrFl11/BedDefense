using Core.Gameplay.Unit.Character;
using Core.Gameplay.Unit.Character.Components;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Test
{
    public class CharacterHealthTesting : MonoBehaviour
    {
        private CharacterHealthContainer _health;

        [Inject]
        private void Construct(CharacterIdentity character)
        {
            _health = character.GetBehaviour<CharacterHealthContainer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
                _health.TakeDamage(Random.Range(2, 15));

            if (Input.GetKeyDown(KeyCode.Y))
                _health.Heal(Random.Range(2, 15));

            if (Input.GetKeyDown(KeyCode.U))
                _health.Health.Set(Random.Range(50, 100));
        }
    }
}