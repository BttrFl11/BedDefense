using Core.Gameplay.Unit.Character;
using ScriptableObjects.SO;
using UnityEngine;
using Utils;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Components
{
    [RequireComponent(typeof(EnemyIdentity))]
    public class EnemyLook : EnemyMonoBehaviour
    {
        private Transform _target;
        private EnemyDataSO _data;
        private float _endRotationZ;

        private Vector2 Direction => (_target.position - transform.position).normalized;

        [Inject]
        private void Construct(CharacterIdentity character)
        {
            _target = character.transform;
        }

        private void Awake()
        {
            _data = Identity.GetData();
        }

        public void Update()
        {
            if (_target == null) return;

            LookAtTarget();
        }

        private void LookAtTarget()
        {
            _endRotationZ = Geometry.GetRotationByDirection(Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, _endRotationZ), _data.RotationSpeed * Time.deltaTime);
        }
    }
}