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

        protected virtual void Awake() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        protected virtual void OnDestroy() { }
        protected virtual void Update() { }
        protected virtual void FixedUpdate() { }
    }
}