using Core.State.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Core.State.States
{
    public class DayState : IDayState
    {
        private DayStateController _controller;

        private List<Timing> _timings = new List<Timing>();

        public DayStateController Controller => _controller;

        public DayState(DayStateController controller)
        {
            List<Timing> timings = new List<Timing>();

            foreach (MethodInfo method in GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                foreach (object customAttribute in method.GetCustomAttributes(false))
                {
                    if (customAttribute.GetType() == typeof(WaitAttribute))
                    {
                        Timing timing = Timing.FromAttribute((WaitAttribute)customAttribute);
                        timing.MethodInfo = method;
                        timing.Target = (object)this;

                        timings.Add(timing);
                    }
                }
            }

            _timings = new(timings);
            _controller = controller;
        }

        public virtual void Enter() 
        {
            foreach (Timing timing in _timings)
            {
                timing.Reset();
            }
        }
        public virtual void Exit() 
        {
            //foreach (Timing timing in _timings)
            //{
            //    timing.Reset();
            //}
        }
        public virtual void Update()
        {
            foreach (Timing timing in _timings)
            {
                timing.Update(Time.deltaTime);
            }
        }

        private class Timing
        {
            private float _currentTime = 0;
            private float _resetTime = 0;
            private float _startTime = 0;

            public object[] Args = new object[0];

            public bool Loop { get; private set; }
            public bool Enabled { get; private set; }
            public object Target { get; set; }
            public MethodInfo MethodInfo { get; set; }

            public Timing(float resetTime, float currentTime, bool loop)
            {
                _resetTime = resetTime;
                _currentTime = currentTime;
                Loop = loop;
                Enabled = true;
                _startTime = _currentTime;
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

                try
                {
                    MethodInfo.Invoke(Target, Args);
                }
                catch (Exception ex)
                {
                    Debug.Log($"Message: {ex}");
                }

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
