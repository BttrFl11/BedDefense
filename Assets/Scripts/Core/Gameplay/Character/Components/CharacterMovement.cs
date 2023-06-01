using Core.Input;
using ScriptableObjects.Data.Character;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Character.Components
{
    [RequireComponent(typeof(CharacterIdentity), typeof(Rigidbody2D))]
    public class CharacterMovement : CharacterMonoBehaviour
    {
        private CharacterMovementData _data;
        private Rigidbody2D _rigidbody;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _data = Identity.GetData().MovementData;
        }

        private void OnEnable()
        {
            _inputService.OnMove += Move;
        }

        private void OnDisable()
        {
            _inputService.OnMove -= Move;
        }

        private void Move(Vector2 direction)
        {
            Vector2 vector = direction.normalized * _data.MoveSpeed;

            _rigidbody.MovePosition(_rigidbody.position + vector);
        }
    }
}