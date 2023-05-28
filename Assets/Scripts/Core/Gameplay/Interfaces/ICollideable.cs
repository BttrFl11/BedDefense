using UnityEngine;

namespace Core.Gameplay.Interfaces
{
    public interface ICollideable
    {
        void OnTriggerEnter2D(Collider2D collider);
    }
}
