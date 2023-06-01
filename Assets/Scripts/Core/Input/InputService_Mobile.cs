using System;
using UnityEngine;

namespace Core.Input
{
    public class InputService_Mobile : IInputService
    {
        public event Action OnAttack;
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;

        public bool IsMobile()
        {
            throw new NotImplementedException();
        }

        public void OnDisable()
        {
            throw new NotImplementedException();
        }

        public void OnEnable()
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}