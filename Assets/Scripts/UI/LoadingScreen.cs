using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Image _progressBar;

        public void SetProgressBarFillAmount(float amount)
        {
            _progressBar.fillAmount = amount;
        }

        public void SetActive(bool active) 
        {
            _panel.SetActive(active);
        }
    }
}