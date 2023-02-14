using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda 
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
                Event.RegisterListener(OnEventRaised);
            }
        }
        
        private void OnDisable()
        {
            if (Event)
            {
                Event.UnregisterListener(OnEventRaised);
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