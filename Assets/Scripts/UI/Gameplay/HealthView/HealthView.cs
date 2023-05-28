using Core.Gameplay.HealthSystem;
using UnityEngine;

namespace UI.Gameplay.HealthView
{
    public abstract class HealthView<T> : MonoBehaviour where T : Health
    {
        protected T _health;

        protected virtual void OnEnable()
        {
            _health.OnChanged += UpdateUI;
        }

        protected virtual void OnDisable()
        {
            _health.OnChanged -= UpdateUI;
        }

        protected virtual void UpdateUI(float currentValue, float maxValue)
        {

        }
    }
}
