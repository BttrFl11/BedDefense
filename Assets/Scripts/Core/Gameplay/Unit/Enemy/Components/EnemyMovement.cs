using Core.Gameplay.Unit.Character;
using ScriptableObjects.Data.Unit.Enemy;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Components
{
    [RequireComponent(typeof(EnemyIdentity), typeof(Rigidbody2D))]
    public class EnemyMovement : EnemyMonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private EnemyMovementData _data;
        private Transform _target;

        private float _moveSpeed;

        private Vector2 Direction => (_target.position - transform.position).normalized;

        [Inject]
        private void Construct(CharacterIdentity character)
        {
            _target = character.transform;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _data = Identity.GetData().MovementData;
        }

        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            _rigidbody.MovePosition(_rigidbody.position + GetSpeed() * Time.deltaTime * Direction);
        }

        public float GetSpeed()
        {
            _moveSpeed = _data.MoveSpeed;

            //
            //

            return _moveSpeed;
        }
    }
}