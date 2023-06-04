using System;
using UnityEngine;

namespace ScriptableObjects.Data.Unit.Enemy
{
    [Serializable]
    public class EnemyPlaceholderData
    {
        [SerializeField] private Vector2 _center;
        [SerializeField] private float _radius;

        public Vector2 Center => _center;
        public float Radius => _radius;
    }
}
