using System;
using UnityEngine;
using Zenject;

namespace Core.Input
{
    public class InputProvider : ITickable, IDisposable
    {
        private IInputService _inputService;
        public IInputService InputService => _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Tick()
        {
            _inputService.Update(Time.deltaTime);
        }

        public void Dispose()
        {
            _inputService.OnDisable();
        }
    }
}