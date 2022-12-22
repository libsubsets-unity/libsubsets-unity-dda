using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    public class BaseEvent<T> : ScriptableObject, IRuntimeInitialize
    {
        private readonly List<UnityAction<T>> eventListener = 
            new List<UnityAction<T>>();
        public T Variable;

        public void Awake()
        {
        }

        public void OnDestroy()
        {
        }

        public void OnEnable()
        {
            RuntimeInstances.Register(this);
        }

        public void OnDisable()
        {
            RuntimeInstances.Unregister(this);
            RuntimeFinalize();
        }

        public void RuntimeInitialize()
        {
        }

        public void RaiseRuntimeInitializeEvent()
        {
        }

        public void RuntimeFinalize()
        {
            eventListener.Clear();
        }

        public void Raise(T value)
        {
            Debug.Log("BaseEvent::Raise: " + name);
            Variable = value;
            for (var i = 0; i < eventListener.Count; ++i)
            {
                eventListener[i].Invoke(value);
            }
        }

        public void Raise()
        {
            Raise(Variable);
        }
               
        public void RegisterListener(UnityAction<T> action)
        {
            if (!eventListener.Contains(action))
                eventListener.Add(action);
        }
       
               
        public void UnregisterListener(UnityAction<T> action)
        {
            if (eventListener.Contains(action))
            {
                eventListener.Remove(action);
            }
        }

        public void UnregisterAllListeners()
        {
            eventListener.Clear();
        }

        public int RegisterListenersCount()
        {
            return eventListener.Count;
        }
    }
}