using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2
{
    
    [CreateAssetMenu]
    public class BaseEvent<T> : ScriptableObject, IRuntimeInitialize
    {
        public int ListenerCount = 0;

        public T Variable;

        private readonly List<UnityAction<T>> eventListener = 
            new List<UnityAction<T>>();
        public void Init()
        {
            eventListener.Clear();
            ListenerCount = 0;
        }
               
        public void Raise(T value)
        {
            Variable = value;
  
            for(int i = eventListener.Count -1; i >= 0; i--)
                eventListener[i].Invoke(value);
        }

        public void Raise()
        {
            Raise(Variable);
        }
               
        public void RegisterListener(UnityAction<T> action)
        {
            if (!eventListener.Contains(action))
                eventListener.Add(action);
            ListenerCount = eventListener.Count();
        }
       
               
        public void UnregisterListener(UnityAction<T> action)
        {
            if (eventListener.Contains(action))
            {
                eventListener.Remove(action);
            }
            ListenerCount = eventListener.Count();
        } 
    }
}