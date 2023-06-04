using Core.State.States;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.State
{
    public abstract class StateController<TState> : ITickable
        where TState : IState
    {
        protected List<TState> _states = new List<TState>();

        protected TState _currentState;

        protected virtual TState CurrentState
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

        public event Action<TState> OnStateChanged;

        private bool Contains<T>() where T : TState
        {
            foreach (var state in _states)
            {
                if (typeof(T) == state.GetType())
                    return true;
            }

            return false;
        }

        public T Find<T>() where T : TState
        {
            foreach (var state in _states)
            {
                if (typeof(T) == state.GetType())
                    return (T)state;
            }

            return default;
        }

        public void Change<T>() where T : TState
        {
            if (Contains<T>() == false)
            {
                Debug.LogWarning($"State {typeof(T).Name} doesnt exists!");
                return;
            }

            TState state = Find<T>();
            if (state.Equals(_currentState))
                return;

            CurrentState = state;
        }

        public void Tick()
        {
            CurrentState._Update();
        }
    }
}
