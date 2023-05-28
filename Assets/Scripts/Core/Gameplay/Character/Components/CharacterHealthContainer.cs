using Core.Gameplay.Character.Systems;
using Core.Gameplay.Interfaces;
using ScriptableObjects.Data.Character;
using UnityEngine;

namespace Core.Gameplay.Character.Components
{
    [RequireComponent(typeof(CharacterIdentity))]
    public class CharacterHealthContainer : CharacterMonoBehaviour, IDamageable
    {
        private CharacterHealth _health;
        private CharacterHealthData _data;

        public CharacterHealth Health => _health;

        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        private void Init()
        {
            _data = Identity.GetData().HealthData;
            _health = new CharacterHealth(_data.Settings);
        }

        protected override void Update()
        {
            base.Update();

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