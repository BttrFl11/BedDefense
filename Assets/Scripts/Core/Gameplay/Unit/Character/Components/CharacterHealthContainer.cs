using Core.Gameplay.Interfaces;
using Core.Gameplay.Unit.Character.Systems;
using ScriptableObjects.Data.Character;
using UnityEngine;

namespace Core.Gameplay.Unit.Character.Components
{
    [RequireComponent(typeof(CharacterIdentity))]
    public class CharacterHealthContainer : CharacterMonoBehaviour, IDamageable
    {
        private CharacterHealth _health;
        private CharacterHealthData _data;

        public CharacterHealth Health => _health;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = Identity.GetData().HealthData;
            _health = new CharacterHealth(_data.Settings);
        }

        private void Update()
        {
            _health.Update(Time.deltaTime);
        }

        public void TakeDamage(float damage)
        {
            bool isDead = _health.Decrease(damage);

            if (isDead)
                Destroy();
        }

        public void Heal(float amount)
        {
            _health.Heal(amount);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}