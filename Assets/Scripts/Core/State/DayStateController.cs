using Core.State.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.State
{
    public class DayStateController
    {
        private List<DayState> _states = new List<DayState>();

        private DayState _currentState;
        private DayState CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState != null)
                    _currentState.Exit();

                _currentState = value;

                _currentState.Enter();

                OnStateChanged?.Invoke(CurrentState);
            }
        }

        public event Action<DayState> OnStateChanged;

        public DayStateController()
        {

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

        private T Find<T>() where T : DayState
        {
            foreach (var state in _states)
            {
                if (typeof(T) == state.GetType())
                    return (T)state;
            }

            return null;
        }

        private T CreateNew<T>() where T : DayState
        {
            Type type = typeof(T);
            T instance = (T)Activator.CreateInstance(type, new object[] { this });
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

        public void Update()
        {
            CurrentState.Update();
        }
    }

}