using UnityEngine;

namespace Core.Input
{
    public class InputProvider
    {
        private IInputService _inputService;
        public IInputService InputService => _inputService;

        public void OnDisable()
        {
            _inputService.OnDisable();
        }

        public void Update()
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