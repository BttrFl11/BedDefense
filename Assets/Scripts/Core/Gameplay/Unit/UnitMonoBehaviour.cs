using UnityEngine;

namespace Core.Gameplay.Unit
{
    public abstract class UnitMonoBehaviour<TIdentity> : MonoBehaviour, IUnitBehaviour where TIdentity : UnitIdentity
    {
        protected static TIdentity _identity;
        public TIdentity Identity
        {
            get
            {
                if (_identity == null)
                    _identity = GetComponent<TIdentity>();

                return _identity;
            }
        }
    }
}