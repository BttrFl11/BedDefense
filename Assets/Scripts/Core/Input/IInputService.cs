using System;
using UnityEngine;

namespace Core.Input
{
    public interface IInputService
    {
        event Action OnAttack;
        /// <summary> Returns normalized move direction </summary>
        event Action<Vector2> OnMove;
        /// <summary> Returns look position in world position </summary>
        event Action<Vector2> OnLook;

        void OnEnable();
        void OnDisable();
        void Update(float deltaTime);
    }
}
