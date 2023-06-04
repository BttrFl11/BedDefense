using System;

namespace Core.State.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FrameAttribute : Attribute
    {
        public FrameAttribute()
        {
        }
    }
}
