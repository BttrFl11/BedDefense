using Core.Gameplay.Interfaces;

namespace Core.Gameplay
{
    public class Health : IHealth
    {
        private HealthSettings _settings;

        public float Value { get; set; }

        public Health(HealthSettings settings)
        {
            _settings = settings;

            Init();
        }

        private void Init()
        {
            Value = _settings.StartValue;
        }

        public void Update(float deltaTime)
        {
            Heal(deltaTime * _settings.RegeneratePerSecond);
        }

        public bool Decrease(float amount)
        {
            Value -= amount;

            if (Value <= 0)
                return true;

            return false;
        }

        public void Heal(float amount)
        {
            Value += amount;

            if (Value > _settings.MaxValue && _settings.LimitedMaxValue)
                Value = _settings.MaxValue;
        }
    }
}
