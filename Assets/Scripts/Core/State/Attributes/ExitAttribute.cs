using System;

namespace Core.State.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExitAttribute : Attribute
    {
        public ExitAttribute() { }
    }
}
