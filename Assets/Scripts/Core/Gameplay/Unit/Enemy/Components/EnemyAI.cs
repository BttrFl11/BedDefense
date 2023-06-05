using Core.Gameplay.Interfaces;
using ScriptableObjects.SO;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Components
{
    [RequireComponent(typeof(EnemyIdentity), typeof(Rigidbody2D))]
    public class EnemyAI : EnemyMonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private EnemyMovement _movement;
        private EnemyDataSO _data;
        private State _state;
        private IEnemyTarget _endTarget;

        private Vector2 EndDirection => (_endTarget.Transform.position - transform.position).normalized;

        private enum State
        {
            Move,
            Attack
        }

        [Inject]
        private void Construct(IEnemyTarget target, EnemyDataSO data)
        {
            _endTarget = target;
            _data = data;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _movement = new EnemyMovement(_data.MovementData, _rigidbody);

            _state = State.Move;
        }

        private void Update()
        {
            switch (_state)
            {
                case State.Move:

                    _movement.Move(EndDirection);

                    break;
                case State.Attack:
                    break;
            }
        }
    }
}