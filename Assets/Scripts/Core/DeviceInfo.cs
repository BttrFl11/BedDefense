using System;

namespace Core
{
    public class DeviceInfo
    {
        public bool IsMobile
        {
            get
            {
#if UNITY_EDITOR || UNITY_STANDALONE
                return false;
#else
                return true;
#endif
            }
        }
    }
}
