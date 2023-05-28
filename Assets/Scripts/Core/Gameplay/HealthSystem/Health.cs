using Core.Gameplay.Interfaces;
using System;

namespace Core.Gameplay.HealthSystem
{
    public abstract class Health : IHealth
    {
        private HealthSettings _settings;

        private float _value;
        private float Value 
        {
            get => _value;
            set
            {
                _value = value;

                OnChanged?.Invoke(Value, _settings.MaxValue);
            }
        }

        private bool Overheal => Value > _settings.MaxValue && _settings.LimitedMaxValue;
        private bool IsDead => Value <= 0;

        /// <summary>
        /// arg1 - current value
        /// arg2 - max value
        /// </summary>
        public event Action<float, float> OnChanged;

        public Health(HealthSettings settings)
        {
            _settings = settings;

            Init();
        }

        private void Init()
        {
            Fill();
        }

        private void Fill()
        {
            Value = _settings.MaxValue;
        }

        public void Update(float deltaTime)
        {
            Heal(deltaTime * _settings.RegeneratePerSecond);
        }

        public void Set(float value)
        {
            Value = value;

            if (Overheal)
                Fill();
        }

        public bool Decrease(float amount)
        {
            Value -= amount;

            if (IsDead)
                return true;

            return false;
        }

        public void Heal(float amount)
        {
            Value += amount;

            if (Overheal)
                Fill();
        }
    }
}
