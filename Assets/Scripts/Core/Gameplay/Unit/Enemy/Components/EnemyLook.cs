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
        private float _endRotationZ;

        private EnemyDataSO _data;

        private Vector2 Direction => (_target.position - transform.position).normalized;

        [Inject]
        private void Construct(CharacterIdentity character, EnemyDataSO data)
        {
            _target = character.transform;
            _data = data;
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