using UnityEngine;

namespace Core.Gameplay.Interfaces
{
    public interface ICollider
    {
        void OnTriggerEnter2D(Collider2D collider);
    }
}
