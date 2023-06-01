using System;
using UnityEngine;
using static UnityEngine.Input;

namespace Core.Input
{
    [Serializable]
    public class InputService_PC : IInputService
    {
        public event Action OnAttack;
        public event Action<Vector2> OnMove;
        /// <summary> Returns mouse point in world position </summary>
        public event Action<Vector2> OnLook;

        private Vector2 _moveDirection;
        private Vector2 _lookDirection;
        private Camera _camera;

        public void OnEnable() 
        {
            FindCamera();
        }

        public void OnDisable() { }

        private void FindCamera()
        {
            _camera = Camera.main;
        }

        public void Update(float deltaTime)
        {
            HandleAttack();
            HandleMove();
            HandleLook();
        }

        private void HandleAttack()
        {
            if(GetMouseButtonDown(0))
            {
                OnAttack?.Invoke();
            }
        }

        private void HandleMove()
        {
            _moveDirection = new Vector2(GetAxis(GameConst.HORIZONTAL_AXIS), GetAxis(GameConst.VERTICAL_AXIS)).normalized;
            if (_moveDirection.magnitude > 0)
                OnMove?.Invoke(_moveDirection);
        }

        private void HandleLook()
        {
            if (_camera == null)
                FindCamera();

            _lookDirection = _camera.ScreenToWorldPoint(mousePosition);
            if(_lookDirection != Vector2.zero)
                OnLook?.Invoke(_lookDirection);
        }

        public bool IsMobile() => false;
    }
}
