using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2.Runtime
{
    public class BaseEvent<T> : ScriptableObject, IRuntimeFinalization
    {
        private readonly List<UnityAction<T>> eventListener = 
            new List<UnityAction<T>>();
        public T Variable;
        
        public void OnEnable()
        {
        }

        public void OnDisable()
        {
            RuntimeFinalize();
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
    }
}