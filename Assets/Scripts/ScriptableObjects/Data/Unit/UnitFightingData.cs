using System;
using UnityEngine;

namespace ScriptableObjects.Data.Unit
{
    public abstract class UnitFightingData
    {
        [SerializeField] private float _attackRange;

        public float AttackRange => _attackRange;
    }
}
