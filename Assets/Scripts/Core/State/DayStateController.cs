using Core.State.States;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.State
{
    public class DayStateController : ITickable
    {
        private List<DayState> _states = new List<DayState>();

        private DayState _currentState;
        private readonly DiContainer _diContainer;

        private DayState CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState != null)
                    _currentState._Exit();

                _currentState = value;

                _currentState._Enter();

                OnStateChanged?.Invoke(CurrentState);
            }
        }

        public event Action<DayState> OnStateChanged;

        public DayStateController(DiContainer diContainer)
        {
            _diContainer = diContainer;

            AddStates();
        }

        private void AddStates()
        {
            Add<DayState_Morning>();
            Add<DayState_Night>();
        }

        private bool Contains<T>() where T : DayState
        {
            foreach (var state in _states)
            {
                if (typeof(T) == state.GetType())
                    return true;
            }

            return false;
        }

        public T Find<T>() where T : DayState
        {
            foreach (var state in _states)
            {
                if (typeof(T) == state.GetType())
                    return (T)state;
            }

            return CreateNew<T>();
        }

        private T CreateNew<T>() where T : DayState
        {
            T instance = _diContainer.Instantiate<T>();
            instance.Init(this);

            return instance;
        }

        public void Add<T>() where T : DayState
        {
            if (Contains<T>())
            {
                Debug.LogWarning($"The given type \"{typeof(T).Name}\" already exists");
                return;
            }

            T state = CreateNew<T>();
            _states.Add(state);

            if (_states.Count == 1)
                CurrentState = state;
        }

        public void Change<T>() where T : DayState
        {
            if (Contains<T>() == false)
                Add<T>();

            T state = Find<T>();
            if (state == _currentState)
                return;

            CurrentState = state;
        }

        public void Tick()
        {
            CurrentState._Update();
        }
    }

}