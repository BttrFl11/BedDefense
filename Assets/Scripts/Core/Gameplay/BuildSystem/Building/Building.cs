using Core.Gameplay.Interfaces;
using ScriptableObjects.SO;
using UnityEngine;

namespace Core.Gameplay.BuildSystem.Building
{
    public abstract class Building<TData> : MonoBehaviour, IDamageable
        where TData : BuildingDataSO
    {
        [SerializeField] private TData _data;

        protected TData Data => _data;
        protected BuildingHealth _health;

        private void OnEnable()
        {
            Init();
        }
        private void Init()
        {
            _health = new BuildingHealth(_data.HealthData.Settings);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            bool died = _health.Decrease(damage);
            if (died)
                Destroy();
        }
    }
}