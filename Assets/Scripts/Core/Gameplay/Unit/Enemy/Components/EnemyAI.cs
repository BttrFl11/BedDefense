using Core.Gameplay.Interfaces;
using ScriptableObjects.Data.Unit.Enemy;
using UnityEngine;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Components
{
    [RequireComponent(typeof(EnemyIdentity), typeof(Rigidbody2D))]
    public class EnemyAI : EnemyMonoBehaviour
    {
        private EnemyMovementData _data;
        private Rigidbody2D _rigidbody;
        private EnemyMovement _movement;

        private IEnemyTarget _target;

        [Inject]
        private void Construct(IEnemyTarget target)
        {
            _target = target;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _data = Identity.GetData().MovementData;

            _movement = new EnemyMovement(_data, _rigidbody);
        }

        private void Update()
        {

        }
    }
}