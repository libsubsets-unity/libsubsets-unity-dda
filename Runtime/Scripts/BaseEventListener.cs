using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Message2 
{
    public class BaseEventListener<T> : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public BaseEvent<T> Event;
        
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<T> Response;
                
        private void OnEnable()
        {
            if (Event)
            {
                Event.RegisterListener(this);
            }
        }
        
        private void OnDisable()
        {
            if (Event)
            {
                Event.UnregisterListener(this);
            }
        }
        
        public virtual void OnEventRaised(T value)
        {
            if (CheckCompareCondition())
            {
                Response.Invoke(value);
            }
        }
        
        protected virtual bool CheckCompareCondition()
        {
            return true;
        }
    }
}