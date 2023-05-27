using System;
using UnityEngine;
using static UnityEngine.Input;

namespace Core.Input
{
    [Serializable]
    public class PCInputService : IInputService
    {
        public event Action OnAttack;
        public event Action<Vector2> OnMove;
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
            ReadAttack();
            ReadMove();
            ReadLook();
        }

        private void ReadAttack()
        {
            if(GetMouseButtonDown(0))
            {
                OnAttack?.Invoke();
            }
        }

        private void ReadMove()
        {
            _moveDirection = new Vector2(GetAxis(GameConst.HORIZONTAL_AXIS), GetAxis(GameConst.VERTICAL_AXIS)).normalized;
            if (_moveDirection.magnitude > 0)
                OnMove?.Invoke(_moveDirection);
        }

        private void ReadLook()
        {
            if (_camera == null)
                FindCamera();

            _lookDirection = _camera.ScreenToWorldPoint(mousePosition);
            if(_lookDirection != Vector2.zero)
                OnLook?.Invoke(_lookDirection);
        }
    }
}
