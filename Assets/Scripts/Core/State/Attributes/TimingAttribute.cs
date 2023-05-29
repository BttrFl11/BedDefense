using System;
using System.Reflection;

namespace Core.State.Attributes
{
    public class TimingAttribute : Attribute
    {
        public float CurrentTime { get; protected set; } = 0.0f;
        public float ResetTime { get; protected set; } = 0.0f;
        public float StartTime { get; protected set; } = 0.0f;
        public float Time => ResetTime;
        public bool Loop { get; protected set; }
        public bool Enable { get; protected set; }
        public object Target { get; set; }
        public MethodInfo Method { get; set; }
        public string Name { get; set; }

        public TimingAttribute(float resetTime, float currentTime, bool loop)
        {
            ResetTime = resetTime;
            CurrentTime = currentTime;
            StartTime = currentTime;
            Loop = loop;
        }
    }
}
