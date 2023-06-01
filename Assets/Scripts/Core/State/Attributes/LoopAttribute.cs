using System;

namespace Core.State.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class LoopAttribute : TimingAttribute
    {
        public LoopAttribute(float resetTime, float currentTime) :
            base(resetTime, currentTime, true)
        {
        }

        public LoopAttribute(float resetTime) :
            base(resetTime, 0, true)
        {
        }
    }
}
