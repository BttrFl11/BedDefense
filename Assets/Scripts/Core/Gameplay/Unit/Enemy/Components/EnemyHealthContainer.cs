using Core.Gameplay.Unit.Enemy.Systems;
using Core.Gameplay.Interfaces;
using ScriptableObjects.Data.Enemy;
using UnityEngine;

namespace Core.Gameplay.Unit.Enemy.Components
{
    [RequireComponent(typeof(EnemyIdentity))]
    public class EnemyHealthContainer : EnemyMonoBehaviour, IDamageable
    {
        private EnemyHealth _health;
        private EnemyHealthData _data;

        public EnemyHealth Health => _health;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = Identity.GetData().HealthData;
            _health = new EnemyHealth(_data.Settings);
        }

        private void Update()
        {
            _health.Update(Time.deltaTime);
        }

        public void TakeDamage(float damage)
        {
            bool isDead = _health.Decrease(damage);

            if (isDead)
                Destroy(gameObject);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}