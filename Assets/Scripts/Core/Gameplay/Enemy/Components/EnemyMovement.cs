using Core.Gameplay.Character;
using Core.Gameplay.Interfaces;
using ScriptableObjects.Data.Enemy;
using UnityEngine;
using Utils;
using Zenject;

namespace Core.Gameplay.Enemy.Components
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

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
            _data = Identity.GetData().MovementData;
        }

        protected override void Update()
        {
            MoveToTarget();
            LookAtTarget();
        }

        private void LookAtTarget()
        {
            transform.rotation = Quaternion.AngleAxis(Geometry.GetRotationByDirection(Direction), Vector3.forward);
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