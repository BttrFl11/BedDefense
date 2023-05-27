using UnityEngine;

namespace Core.Input
{
    public class InputProvider : MonoBehaviour
    {
        private IInputService _inputService;
        public IInputService InputService => _inputService;

        private void OnDisable()
        {
            _inputService.OnDisable();
        }

        private void Update()
        {
            _inputService.Update(Time.deltaTime);
        }

        public void CreatePCInputService()
        {
            _inputService = new PCInputService();

            _inputService.OnEnable();
        }

        public void CreateMobileInputService()
        {
            throw new System.NotImplementedException();
        }
    }
}