using System;

namespace Core.Gameplay
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
