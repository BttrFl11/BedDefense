using System;

namespace Core.State.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class WaitAttribute : TimingAttribute
    {
        public WaitAttribute(float time) : base(0, time, false)
        {
        }
    }
}
