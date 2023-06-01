using ScriptableObjects.SO;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Unit
{
    public abstract class UnitIdentity : MonoBehaviour
    {
        [SerializeField] protected UnitDataSO _data;

        protected List<IUnitBehaviour> _behaviours = new List<IUnitBehaviour>();
        public IEnumerable<IUnitBehaviour> Behaviours 
        { 
            get 
            {
                if (_behaviours.Count == 0)
                    _behaviours.AddRange(GetComponents<IUnitBehaviour>());

                return _behaviours;
            } 
        }

        public T GetBehaviour<T>() where T : IUnitBehaviour
        {
            foreach (var behaviour in Behaviours)
            {
                if (behaviour is T beh)
                    return beh;
            }

            return default;
        }
        public virtual T GetData<T>() where T : UnitDataSO
        {
            return (T)_data;
        }
    }
}