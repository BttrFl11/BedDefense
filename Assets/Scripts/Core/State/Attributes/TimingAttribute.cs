using System;

namespace Core.State.Attributes
{
    public class TimingAttribute : Attribute
    {
        public float CurrentTime { get; protected set; } = 0.0f;
        public float ResetTime { get; protected set; } = 0.0f;
        public float StartTime { get; protected set; } = 0.0f;
        public bool Loop { get; protected set; }

        public TimingAttribute(float resetTime, float currentTime, bool loop)
        {
            ResetTime = resetTime;
            CurrentTime = currentTime;
            StartTime = currentTime;
            Loop = loop;
        }
    }
}
