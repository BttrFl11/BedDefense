using System;

namespace Core.State.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class EnterAttribute : Attribute
    {
        public EnterAttribute() { }
    }
}
