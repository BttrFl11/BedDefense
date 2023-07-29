using System;
using UnityEngine;
using Zenject;

namespace Core.Input
{
    public class InputProvider : ITickable, IFixedTickable, IDisposable
    {
        private IInputService _inputService;
        public IInputService InputService => _inputService;

        public InputProvider(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Dispose()
        {
            _inputService.OnDisable();
        }

        public void Tick()
        {
            _inputService.Tick();
        }

        public void FixedTick()
        {
            _inputService.FixedTick();
        }
    }
}