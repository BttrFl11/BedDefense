using System;

namespace Core.Gameplay.HealthSystem
{
    [Serializable]
    public struct HealthSettings
    {
        public float StartValue;
        public float MaxValue;
        public float RegeneratePerSecond;
        public bool LimitedMaxValue;
    }
}
