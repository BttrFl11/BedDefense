using System;
using UnityEngine;

namespace ScriptableObjects.Data.Unit
{
    public abstract class UnitMovementData
    {
        [SerializeField] private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;
    }
}
