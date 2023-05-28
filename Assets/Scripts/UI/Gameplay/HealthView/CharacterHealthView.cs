using Core.Gameplay.Character;
using Core.Gameplay.Character.Components;
using Core.Gameplay.Character.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Gameplay.HealthView
{
    public class CharacterHealthView : HealthView<CharacterHealth>
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private TMP_Text _healthText;

        [Inject]
        private void Construct(CharacterIdentity character)
        {
            _health = character.GetBehaviour<CharacterHealthContainer>().Health;
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