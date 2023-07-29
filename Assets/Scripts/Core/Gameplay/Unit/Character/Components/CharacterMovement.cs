using Core.Input;
using ScriptableObjects.Data.Unit.Character;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Unit.Character.Components
{
    [RequireComponent(typeof(CharacterIdentity), typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterMovementData _data;
        private Rigidbody2D _rigidbody;

        [Inject] private IInputService _inputService;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _data = Identity.GetData().Movement;
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