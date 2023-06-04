using ScriptableObjects.Data.Unit.Enemy;
using UnityEngine;

namespace Core.Gameplay.Unit.Enemy.Components
{
    public class EnemyMovement
    {
        private Rigidbody2D _rigidbody;
        private EnemyMovementData _data;
        private float _moveSpeed;

        public EnemyMovement(EnemyMovementData data, Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _data = data;
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + GetSpeed() * Time.deltaTime * direction);
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
