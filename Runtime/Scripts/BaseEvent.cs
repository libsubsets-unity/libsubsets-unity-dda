using System;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    [CreateAssetMenu]
    public class BaseEvent<T> : ScriptableObject
    {
        protected readonly List<BaseEventListener<T>> eventListeners = 
            new List<BaseEventListener<T>>();
        protected readonly List<UnityAction<T>> eventActions = 
            new List<UnityAction<T>>();

        public T Variable;
               
        public void Raise(T value)
        {
            Variable = value;
            
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
                   
            for(int i = eventActions.Count -1; i >= 0; i--)
                eventActions[i].Invoke(value);
        }

        public void Raise()
        {
            Raise(Variable);
        }
        
        public void RegisterListener(BaseEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }
               
        public void RegisterListener(UnityAction<T> action)
        {
            eventActions.Add(action);
        }
       
        public void UnregisterListener(BaseEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
               
        public void UnregisterListener(UnityAction<T> action)
        {
            if (eventActions.Contains(action))
                eventActions.Remove(action);
        } 
    }
}