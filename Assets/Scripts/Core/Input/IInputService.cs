using System;
using UnityEngine;

namespace Core.Input
{
    public interface IInputService
    {
        event Action OnAttack;
        /// <summary> Returns normalized move direction </summary>
        event Action<Vector2> OnMove;
        event Action<Vector2> OnLook;

        void OnEnable();
        void OnDisable();
        void Update(float deltaTime);
        bool IsMobile();
    }
}
