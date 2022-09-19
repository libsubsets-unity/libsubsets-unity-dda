using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        protected readonly List<GameEventListener> eventListeners = 
            new List<GameEventListener>();
        protected readonly List<Action> eventActions = 
            new List<Action>();
        
        public void Raise()
        {
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
            
            for(int i = eventActions.Count -1; i >= 0; i--)
                eventActions[i].Invoke();
        }
        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }
        
        public void RegisterListener(Action action)
        {
            eventActions.Add(action);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
        
        public void UnregisterListener(Action action)
        {
            if (eventActions.Contains(action))
                eventActions.Remove(action);
        }
    }
}