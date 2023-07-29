using System;
using UnityEngine;

namespace Core.Input
{
    public interface IInputService
    {
        event Action OnAttack;
        /// <summary> Returns normalized move direction </summary>
        event Action<Vector2> OnMove;
        /// <summary> Returns normalized look direction on mobile platforms or returns look world position on pc </summary>
        event Action<Vector2> OnLook;

        void OnEnable();
        void OnDisable();
        void Tick();
        void FixedTick();
        bool IsMobile();
    }
}
