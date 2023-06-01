using Core.Gameplay.Unit.Enemy.Components;
using Core.Gameplay.Unit.Enemy.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay.HealthView
{
    public class EnemyHealthView : HealthView<EnemyHealth>
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _healthImage;
        [SerializeField] private EnemyHealthContainer _healthContainer;

        protected override void OnEnable()
        {
            _health = _healthContainer.Health;

            base.OnEnable();
        }

        protected override void UpdateUI(float currentValue, float maxValue)
        {
            base.UpdateUI(currentValue, maxValue);

            if (_healthImage != null)
                _healthImage.fillAmount = currentValue / maxValue;

            if(_healthText != null)
                _healthText.text = currentValue.ToString("0");
        }
    }
}