using Core.State.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Core.State.States
{
    public abstract class AttributedState : IState
    {
        private List<Timing> _timings = new List<Timing>();
        private List<MethodInfoObject> _enters = new List<MethodInfoObject>();
        private List<MethodInfoObject> _exits = new List<MethodInfoObject>();
        private List<MethodInfoObject> _frames = new List<MethodInfoObject>();

        public AttributedState()
        {
            AddMethodsFromAttributes();
        }

        private void AddMethodsFromAttributes()
        {
            foreach (MethodInfo method in GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                foreach (object customAttribute in method.GetCustomAttributes(false))
                {
                    MethodInfoObject methodObj = new MethodInfoObject()
                    {
                        Method = method,
                        Target = this
                    };

                    AddTiming(customAttribute, method);

                    if (customAttribute.GetType() == typeof(EnterAttribute))
                    {
                        _enters.Add(methodObj);
                    }
                    if (customAttribute.GetType() == typeof(ExitAttribute))
                    {
                        _exits.Add(methodObj);
                    }
                    if (customAttribute.GetType() == typeof(FrameAttribute))
                    {
                        _frames.Add(methodObj);
                    }
                }
            }

            void AddTiming(object customAttribute, MethodInfo method)
            {
                if (customAttribute is TimingAttribute attribute)
                {
                    Timing timing = Timing.FromAttribute(attribute);
                    timing.Method = method;
                    timing.Target = this;

                    _timings.Add(timing);
                }
            }
        }

        public virtual void _Enter()
        {
            foreach (Timing timing in _timings)
                timing.Reset();

            foreach (var enter in _enters)
                enter.Invoke();
        }

        public virtual void _Exit()
        {
            foreach (var exit in _exits)
                exit.Invoke();
        }

        public virtual void _Update()
        {
            foreach (Timing timing in _timings)
                timing.Update(Time.deltaTime);

            foreach (var frame in _frames)
                frame.Invoke();
        }

        private class MethodInfoObject
        {
            public MethodInfo Method { get; set; }
            public object Target { get; set; }

            public void Invoke()
            {
                try
                {
                    Method.Invoke(Target, null);
                }
                catch (Exception ex)
                {
                    Debug.Log($"Message: {ex}");
                }
            }
        }

        private class Timing : MethodInfoObject
        {
            private float _currentTime = 0;
            private float _resetTime = 0;
            private float _startTime = 0;

            public bool Loop { get; private set; }
            public bool Enabled { get; private set; }

            public Timing(float resetTime, float currentTime, bool loop)
            {
                _resetTime = resetTime;
                _currentTime = currentTime;
                _startTime = _currentTime;
                Loop = loop;
                Enabled = true;
            }

            public void Reset()
            {
                _currentTime = _startTime;
                Enabled = true;
            }

            public void Stop()
            {
                Enabled = false;
            }

            public void Update(float deltaTime)
            {
                if (Enabled == false) return;

                _currentTime -= deltaTime;

                if (_currentTime > 0) return;

                Invoke();

                if (Loop)
                    _currentTime += _resetTime;
                else
                    Stop();
            }

            public static Timing FromAttribute(TimingAttribute attr)
            {
                return new(attr.ResetTime, attr.CurrentTime, attr.Loop);
            }
        }
    }
}
