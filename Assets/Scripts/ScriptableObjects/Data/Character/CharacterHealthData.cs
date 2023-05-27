using Core.Gameplay;
using ScriptableObjects.Data.Unit;
using System;
using UnityEngine;

namespace ScriptableObjects.Data.Character
{
    [Serializable]
    public class CharacterHealthData : UnitHealthData
    {
        [SerializeField] private HealthSettings _settings;

        public HealthSettings Settings => _settings;
    }
}
